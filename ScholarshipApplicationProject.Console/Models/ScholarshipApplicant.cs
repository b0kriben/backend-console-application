namespace ScholarshipApplicationProject.Console.Models
{
    public class ScholarshipApplicant
    {
        private decimal _amount;
        private string _email;

        public ScholarshipApplicant(string email, string name)
        {
            if (string.IsNullOrEmpty(email)) 
                throw new ArgumentNullException("email");
            if (string.IsNullOrEmpty(name)) 
                throw new ArgumentNullException("name");
            _email = email;
            Name = name;
            _amount = 0;
        }
        public string Name { get; set; }
        public decimal Amount { get => _amount; set => _amount = value; }
        public string Email { get => _email; set => _email = value; }

        public void Win(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentNullException(nameof(amount));
            _amount+=amount;
        }

        public override string ToString()
        {
            return $"{Name} ({_email}) {_amount} Ft";
        }
    }
}
