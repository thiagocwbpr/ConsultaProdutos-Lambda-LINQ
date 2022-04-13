using System.Globalization;

namespace ExercicioLambdaLINQ.Entities {
    internal class Products {
        public string Name { get; set; }
        public double Price { get; set; }
        public Products(string Name, double Price) {
            this.Name = Name;
            this.Price = Price;
        }
        public override string ToString() {
            return Name + " " + Price.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
