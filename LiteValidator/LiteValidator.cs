namespace LiteValidator
{
    public class ValidationRule<T>
    {
        public Func<T, bool>? Rule { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public bool ContinueIfNextValid { get; set; }
    }

    public class ValidationResult
    {
        public bool IsValid { get; set; } = true;
        public HashSet<string> Messages { get; set; } = [];
        public void AddError(string message)
        {
            IsValid = false;
            Messages.Add(message);
        }
    }
    public class RuleBuilder<T>(LiteValidator<T> validator, ValidationRule<T> rule)
    {
        private readonly LiteValidator<T> _validator = validator;
        private readonly ValidationRule<T> _rule = rule;

        public RuleBuilder<T> AddError(string errorMessage)
        {
            _rule.ErrorMessage = errorMessage;
            return this;
        }

        public LiteValidator<T> Then() => _validator;
        public ValidationResult Validate(T obj) => _validator.Validate(obj);
        public LiteValidator<T> Build() => _validator;
    }

    public class LiteValidator<T>
    {
        private readonly List<ValidationRule<T>> _rules = [];

        public RuleBuilder<T> AddRule(Func<T, bool> rule, bool continueIfNextValid = false)
        {
            var validationRule = new ValidationRule<T> 
            { 
                Rule = rule,
                ContinueIfNextValid = continueIfNextValid
            };
            _rules.Add(validationRule);
            return new RuleBuilder<T>(this, validationRule);
        }

        public ValidationResult Validate(T obj)
        {
            var result = new ValidationResult();
            bool isCurrentRuleValid;

            for (int i = 0; i < _rules.Count; i++)
            {
                var rule = _rules[i];

                if(rule.ContinueIfNextValid && i + 1 < _rules.Count)
                {
                    var nextRule = _rules[i + 1];
                    isCurrentRuleValid = nextRule != null && nextRule.Rule(obj);

                    if (!isCurrentRuleValid)
                    {
                        result.AddError(nextRule.ErrorMessage);
                        continue;
                    }
                }

                isCurrentRuleValid = rule.Rule != null && rule.Rule(obj);                

                if (!isCurrentRuleValid)                                    
                    result.AddError(rule.ErrorMessage);
            }
            return result;
        }
    }
}