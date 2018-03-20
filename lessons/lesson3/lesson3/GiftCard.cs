using System;
using System.Net;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace lesson3
{
    public class GiftCard : IItem
    {
        /// <summary>
        /// Creates a new GiftCard.
        /// </summary>
        /// <param name="amount">Amount must be greater than 0.</param>
        public GiftCard(decimal amount, Currency currency)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be greater than 0.", nameof(amount));

            Amount = amount;
            Currency = currency;
            Code = Guid.NewGuid().ToString();
            IsRedeemed = false;
        }

        /// <summary>
        /// Value of this gift card.
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        /// Currency of Amount.
        /// </summary>
        public Currency Currency { get; }

        /// <summary>
        /// The unique code to redeem this gift card.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Redeems this gift card. Can only be performed once.
        /// </summary>
        public void Redeem()
        {
            if (IsRedeemed) throw new InvalidOperationException ($"Gift card {Code} has already been redeemed.");
            IsRedeemed = true;
        }

        /// <summary>
        /// True, if this gift card has been redeemed. 
        /// </summary>
        public bool IsRedeemed { get; private set; }

        #region IItem implementation

        public decimal GetPrice (Currency currency)
        {
            // if the price is requested in it's own currency, then simply return the stored price
            if (currency == Currency) return Amount;

            var from = Currency.ToString();
            var to = currency.ToString();

            // use web service to query current exchange rate
            // request : https://api.fixer.io/latest?base=EUR&symbols=USD
            // response: {"base":"EUR","date":"2018-01-24","rates":{"USD":1.2352}}
            var url = $"https://api.fixer.io/latest?base={from}&symbols={to}";
            // download the response as string
            var data = new WebClient().DownloadString(url);
            // parse JSON
            var json = JObject.Parse(data);
            // convert the exchange rate part to a decimal 
            var rate = decimal.Parse((string)json["rates"][to], CultureInfo.InvariantCulture);

            // and finally perform the currency conversion
            return Amount * rate;
        }

        public string Description => "GiftCard " + Code;

        #endregion
    }
}

