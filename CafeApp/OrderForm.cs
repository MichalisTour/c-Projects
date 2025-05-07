using System.Text;
using System.Windows.Forms;

namespace CafeApp
{
    public partial class OrderForm : Form
    {
        private List<Product> productsList;
        private List<Product> drinksList;
        private List<Product> foodList;
        private List<NumericUpDown> numericUpDownDrinksList;
        private List<NumericUpDown> numericUpDownsFoodList;
        private List<CheckBox> checkBoxFoodList;
        private List<CheckBox> checkBoxDrinksList;
        private int receiptNumber;
        private int tableNumber;



        public OrderForm()
        {
            InitializeComponent();
            productsList = new List<Product>
            {
                new Product("Espresso",2.50f,"Drinks"),
                new Product("Double Espresso",3.50f,"Drinks"),
                new Product("Cappuccino",3.80f,"Drinks"),
                new Product("Double Cappuccino",5.00f,"Drinks"),
                new Product("Greek Coffee",3.00f,"Drinks"),
                new Product("Orange Juice",5.00f,"Drinks"),
                new Product("Cheese Burger",12.00f,"Food"),
                new Product("Pizza Special",15.80f,"Food"),
                new Product("White Pancakes",9.00f,"Food"),
                new Product("Avocado Toast",7.80f,"Food"),
                new Product("Greek Omelet",8.80f,"Food"),
                new Product("Ham/Cheese Toast",4.00f,"Food")
            };
            drinksList = productsList.Where(p => p.Category == "Drinks").ToList();
            foodList = productsList.Where(p => p.Category == "Food").ToList();

            numericUpDownDrinksList = new List<NumericUpDown>
            {
                EspressoUpDown, DbEspressoUpDown, CappuccinoUpDown, DbCappuccinoUpDown, GreekCoffeeUpDown, OrangeJuiceUpDown
            };
            numericUpDownsFoodList = new List<NumericUpDown>
            {
                BurgerUpDown, PizzaUpDown, PancakesUpDown, AvocadoToastUpDown, OmeletteUpDown, ToastUpDown
            };
            checkBoxDrinksList = new List<CheckBox>
            {
                checkEspresso, checkDoubleEspresso, checkCappuccino, checkDoubleCappucino, checkGreek, checkFreshOrangeJuice
            };
            checkBoxFoodList = new List<CheckBox>
            {
                checkBurger, checkPizzaSpecial, checkPanCakes, checkAvocadoToast, checkOmelette, checkToast
            };
            User user = new User();
            label1.Text = $"Employee: {user.Name}\nLoginTime: {DateTime.Now.ToString()}";
            Random random = new Random();
            receiptNumber = random.Next(1, 500);
            tableNumber = random.Next(1, 30);

        }

        //Initialize the drinks labels with the objects.name
        private void OrderForm_Load(object sender, EventArgs e)
        {
            var drinkLabels = new List<Label> { EpsressoLabel, DbEpsressoLabel, CappLabel, DbCappLabel, GreekLabel, OrangeJuiceLabel };

            int i = 0;
            foreach (var item in drinksList)
            {
                drinkLabels[i].Text = $"{item.Name} {item.Price}€";
                i++;
            }

            //Initialize the food labels with the objects.name
            var foodLabels = new List<Label> { BurgerLabel, PizzaLabel, PancakesLabel, AvocadoToastLabel, OmeletteLabel, ToastLabel };

            int x = 0;
            foreach (var item in foodList)
            {
                foodLabels[x].Text = $"{item.Name} {item.Price}€";
                x++;
            }
        }

        //Update the Quantities of the products
        private void UpdateProductQuantities()
        {
            for (int i = 0; i < numericUpDownDrinksList.Count; i++)
            {
                drinksList[i].Quantity = (int)numericUpDownDrinksList[i].Value;
            }

            for (int i = 0; i < numericUpDownsFoodList.Count; i++)
            {
                foodList[i].Quantity = (int)numericUpDownsFoodList[i].Value;
            }
        }

        public void CalculateTotalDrinks()
        {
            UpdateProductQuantities();

            decimal total = 0;
            decimal vat = 0;
            decimal totalCost = 0;
            for (int i = 0; i < checkBoxDrinksList.Count; i++)
            {
                if (checkBoxDrinksList[i].Checked)
                {
                    decimal price = (decimal)drinksList[i].Price;
                    int quanity = drinksList[i].Quantity;
                    total += price * quanity;
                    vat = total * (decimal)0.24;
                    totalCost = vat + total;
                }
                else
                {
                    numericUpDownDrinksList[i].Value = 0;
                }
            }

            TotalDrinksBox.Text = $"{total.ToString()}";
            VatDrinksBox.Text = $"{vat.ToString("F2")}";
            TotalAmountDrinksBox.Text = $"{totalCost.ToString("F2")}";
        }

        public void CalculateTotalFood()
        {
            UpdateProductQuantities();

            decimal total = 0;
            decimal vat = 0;
            decimal totalCost = 0;

            for (int i = 0; i < checkBoxFoodList.Count; i++)
            {
                if (checkBoxFoodList[i].Checked)
                {
                    decimal price = (decimal)foodList[i].Price;
                    int quantity = foodList[i].Quantity;
                    total += price * quantity;
                    vat = total * (decimal)0.24;
                    totalCost = vat + total;
                }
                else
                {
                    numericUpDownsFoodList[i].Value = 0;
                }
            }
            TotalFoodBox.Text = $"{total.ToString()}";
            VatFoodBox.Text = $"{vat.ToString("F2")}";
            TotalAmountFoodBox.Text = $"{totalCost.ToString("F2")}";
        }
        public void CalculateTotalCost()
        {
            decimal totalDrinks = decimal.Parse(TotalDrinksBox.Text);
            decimal totalFood = decimal.Parse(TotalFoodBox.Text);
            decimal vatDrinks = decimal.Parse(VatDrinksBox.Text);
            decimal vatFood = decimal.Parse(VatFoodBox.Text);
            decimal totalDrinksVat = decimal.Parse(TotalAmountDrinksBox.Text);
            decimal totalFoodVat = decimal.Parse(TotalAmountFoodBox.Text);


            decimal total = totalDrinks + totalFood;
            decimal totalVat = vatDrinks + vatFood;
            decimal totalCostVat = total + totalVat;
            totalBox.Text = total.ToString();
            vatTotalBox.Text = totalVat.ToString();
            totalAmountTotalBox.Text = totalCostVat.ToString();
        }

        public void Receipt()
        {
            
            receiptBox.Clear();
            receiptBox.AppendText("\t☕ Café Latte Lab ☕\n");
            receiptBox.AppendText("-----------------------------------\n\n");
            receiptBox.AppendText($" Receipt No: #{receiptNumber}\t Table: {tableNumber}");

            List<Product> receiptItems = new List<Product>();
            var allCheckBoxes = checkBoxDrinksList.Concat(checkBoxFoodList).ToList();

            int i = 0;
            foreach (CheckBox check in allCheckBoxes)
            {
                if (check.Checked && productsList[i].Quantity > 0)
                {
                    receiptItems.Add(productsList[i]);
                    receiptBox.AppendText($"\n{productsList[i].Name.PadRight(14)} \t {productsList[i].Quantity.ToString().PadLeft(3)} VAT: 24%");
                }
                i++;
            }
            receiptBox.AppendText("\n-----------------------------------\n");
            receiptBox.AppendText($"Total: {totalBox.Text}\n");
            receiptBox.AppendText($"VAT(24%): {vatTotalBox.Text}\n");
            receiptBox.AppendText($"TotalCost: {totalAmountTotalBox.Text} \n");
            receiptBox.AppendText("-----------------------------------");
            receiptBox.AppendText($"\t{DateTime.Now.ToString()}\n");
            receiptBox.AppendText($"\tThank you for your visit!\n      Follow us: @Café_Latte_Lab");
        }
        private void EspressoUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalDrinks();
            CalculateTotalCost();
        }

        private void DbEspressoUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalDrinks();
            CalculateTotalCost();
        }

        private void CappuccinoUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalDrinks();
            CalculateTotalCost();
        }

        private void DbCappuccinoUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalDrinks();
            CalculateTotalCost();
        }

        private void GreekCoffeeUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalDrinks();
            CalculateTotalCost();
        }

        private void OrangeJuiceUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalDrinks();
            CalculateTotalCost();
        }

        private void BurgerUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalFood();
            CalculateTotalCost();
        }

        private void PizzaUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalFood();
            CalculateTotalCost();
        }

        private void PancakesUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalFood();
            CalculateTotalCost();
        }

        private void AvocadoToastUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalFood();
            CalculateTotalCost();
        }

        private void OmeletteUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalFood();
            CalculateTotalCost();
        }

        private void ToastUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalFood();
            CalculateTotalCost();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Receipt();

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            receiptBox.Clear();

            foreach (var nud in numericUpDownDrinksList.Concat(numericUpDownsFoodList))
            {
                nud.Value = 0;
            }

            foreach (var chk in checkBoxDrinksList.Concat(checkBoxFoodList))
            {
                chk.Checked = false;
            }
            foreach (var product in productsList)
            {
                product.Quantity = 0;
            }

        }

        private void changeUser_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Title = "Save Receipt";

            if (!string.IsNullOrWhiteSpace(receiptBox.Text))
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    string content = receiptBox.Text;
                    File.WriteAllText(filePath, content);
                    MessageBox.Show($"You saved your receipt {filePath}");
                }
            }
            else
            {
                MessageBox.Show("Receipt is empty.");
            }

        }
    }
}
