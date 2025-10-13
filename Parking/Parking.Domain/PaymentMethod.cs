namespace Domain
{
    public record PaymentMethod
    {
        public string Payment { get; }
        private PaymentMethod(string payment)
        {
            Payment = payment;
        }
        public static PaymentMethod Create(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Способ оплаты был пустым.");
            string forma = name.Trim();
            if (forma.Length <= 1)
                throw new ArgumentException("Способ оплаты слишком мал.");
            if (forma.Length >= 50)
                throw new ArgumentException("Способ оплаты слишком большой.");
            return new PaymentMethod(forma);
        }
    }
}
