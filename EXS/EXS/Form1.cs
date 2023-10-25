using EXS.Entities;
using EXS.Rules;
using EXS.UserInterface;
using System.Collections.Generic;
using System.Diagnostics;

namespace EXS
{
    public partial class Form1 : Form
    {
        DatabaseManager dbMan = DatabaseManager.Instance;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        { }

        private void variáveisToolStripMenuItem_Click(object sender, EventArgs e)
        { }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            VariavelForm menuToAddVariables = new VariavelForm();
            menuToAddVariables.Show();
        }

        private void verVariáveisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditVariable windowToEditVars = new EditVariable();
            windowToEditVars.Show();
        }

        private void criarRegraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateRule newRule = new CreateRule();
            newRule.Show();
        }

        private void excluirRegraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modRule modifyRl = new modRule();
            modifyRl.Show();
        }

        private void iniciarQuestionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<RuleCondition> userInputs = new List<RuleCondition>();
            List<(int, string)> allVarsToAnswer = dbMan.GetVarNamesIds();   //As Ids e Nomes das variáveis
            List<Regra> lisReg = dbMan.GetRegras();                         //As regras, com Id de variáveis de saída
            List<int> foundAsOutputInRule = new List<int>();                //As Ids das variáveis nas regras, para ignorar

            foreach (var rule in lisReg)
            {
                int varSaidaId = rule.IdVariavelSaida;

                if (allVarsToAnswer.Any(x => x.Item1 == varSaidaId))
                {
                    foundAsOutputInRule.Add(varSaidaId);
                }
            }

            foreach (var var in allVarsToAnswer)
            {
                if (!foundAsOutputInRule.Contains(var.Item1))
                {
                    var currentIteration = dbMan.GetVarById(var.Item1);

                    string typeOThis = dbMan.GetVarType(var.Item2);

                    if (typeOThis == "Univalorada")
                    {
                        InterfaceUni iUni = new InterfaceUni(userInputs, currentIteration);
                        iUni.ShowDialog();
                    }
                    else if (typeOThis == "Numerica")
                    {
                        InterfaceNum iNum = new InterfaceNum(userInputs, currentIteration);
                        iNum.ShowDialog();
                    }
                }
            }

            List<(List<RuleCondition> Conditions, int IdVariavelSaida, int IdValorSaida)> splitRules = SplitRulesAndReturns();
            List<(string varName, string valName)> listOfFoundResults = new List<(string, string)>();

            foreach (var ruleConditionalAndOutputs in splitRules)
            {
                listOfFoundResults.Add(CheckRuleConditions(userInputs, ruleConditionalAndOutputs.Conditions, ruleConditionalAndOutputs.IdVariavelSaida, ruleConditionalAndOutputs.IdValorSaida));
            }

            ResultScreen finalAnswer = new ResultScreen(listOfFoundResults);
            finalAnswer.Show();
        }

        public List<(List<RuleCondition> Conditions, int IdVariavelSaida, int IdValorSaida)> SplitRulesAndReturns()
        {
            List<(List<RuleCondition> Conditions, int IdVariavelSaida, int IdValorSaida)> regras = new List<(List<RuleCondition> Conditions, int IdVariavelSaida, int IdValorSaida)>();

            foreach (var regra in dbMan.GetRegras())
            {
                List<RuleCondition> conditionsList = new List<RuleCondition>();

                string[] conditionItems = regra.KBQuery.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string conditionItem in conditionItems)
                {
                    RuleCondition condition = new RuleCondition();
                    string tempConditionItem = conditionItem;

                    if (tempConditionItem.StartsWith("&&") || tempConditionItem.StartsWith("||"))
                    {
                        int opLength = 2;
                        condition.CondOp = tempConditionItem.Substring(0, opLength);
                        tempConditionItem = tempConditionItem.Substring(opLength);
                    }

                    string[] parts = tempConditionItem.Split(new string[] { "==", "!=", "<=", ">=", "<", ">" }, StringSplitOptions.None);

                    if (parts.Length == 2)
                    {
                        string[] comparators = { "==", "!=", "<=", ">=", "<", ">" };
                        string operadorMat = "";
                        foreach (var comparator in comparators)
                        {
                            if (tempConditionItem.Contains(comparator))
                            {
                                operadorMat = comparator;
                                break;
                            }
                        }

                        condition.Variable = parts[0].Trim();
                        condition.Operator = operadorMat.Trim();
                        condition.Value = parts[1].Trim();
                    }

                    conditionsList.Add(condition);
                }


                regras.Add((conditionsList, regra.IdVariavelSaida, regra.IdValorSaida));
            }
            return regras;
        }
        public (string VariableName, string ValueName) CheckRuleConditions(List<RuleCondition> userInputs, List<RuleCondition> conditions, int idVariavelSaida, int idValorSaida)
        {
            List<bool> conditionResults = new List<bool>();

            foreach (var condition in conditions)
            {
                RuleCondition userInputCondition = userInputs.FirstOrDefault(u => u.Variable == condition.Variable);

                if (userInputCondition != null)
                {
                    bool isConditionMet = IsMatchingCondition(userInputCondition, condition);
                    conditionResults.Add(isConditionMet);
                }
                else
                {
                    conditionResults.Add(false);
                }
            }

            bool finalResult = EvaluateCompositeConditions(conditions, conditionResults);

            if (finalResult)
            {
                string variableName = dbMan.GetVarName(idVariavelSaida);
                string valueName = dbMan.GetValName(idValorSaida);
                return (variableName, valueName);
            }

            return (null, null);
        }
        private bool EvaluateCompositeConditions(List<RuleCondition> conditions, List<bool> conditionResults)
        {
            List<bool> doThoseFirst = new List<bool>();
            bool finalResult = true;

            for (int i = 0; i < conditions.Count; i++)
            {
                bool conditionResult = conditionResults[i];
                string logicalOperator = conditions[i].CondOp;

                if (logicalOperator == "||")
                {
                    finalResult = finalResult || conditionResult;
                    doThoseFirst.Add(finalResult);
                }
                else if (logicalOperator == "&&")
                {
                    doThoseFirst.Add(finalResult);
                }
            }

            for (int i = 0; i < doThoseFirst.Count; i++)
            {
                bool conditionResult = conditionResults[i];
                string logicalOperator = conditions[i].CondOp;

                if (logicalOperator == "||")
                {
                    finalResult = finalResult || conditionResult;
                }
                else if (logicalOperator == "&&")
                {
                    finalResult = finalResult && conditionResult;
                }
            }

            return finalResult;
        }

        private bool IsMatchingCondition(RuleCondition userInputCondition, RuleCondition ruleCondition)
        {
            if (string.Equals(userInputCondition.Variable, ruleCondition.Variable, StringComparison.OrdinalIgnoreCase))
            {
                if (string.Equals(ruleCondition.Operator, "==", StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(userInputCondition.Value, ruleCondition.Value, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else if (string.Equals(ruleCondition.Operator, "!=", StringComparison.OrdinalIgnoreCase) &&
                         !string.Equals(userInputCondition.Value, ruleCondition.Value, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else if (int.TryParse(userInputCondition.Value, out int userInputValue) && int.TryParse(ruleCondition.Value, out int ruleValue))
                {
                    if (string.Equals(ruleCondition.Operator, "<", StringComparison.OrdinalIgnoreCase) && userInputValue < ruleValue)
                    {
                        return true;
                    }
                    else if (string.Equals(ruleCondition.Operator, ">", StringComparison.OrdinalIgnoreCase) && userInputValue > ruleValue)
                    {
                        return true;
                    }else if (string.Equals(ruleCondition.Operator, "<=", StringComparison.OrdinalIgnoreCase) && userInputValue <= ruleValue)
                    {
                        return true;
                    }
                    else if (string.Equals(ruleCondition.Operator, ">", StringComparison.OrdinalIgnoreCase) && userInputValue > ruleValue)
                    {
                        return true;
                    }
                    else if (string.Equals(ruleCondition.Operator, ">=", StringComparison.OrdinalIgnoreCase) && userInputValue >= ruleValue)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}