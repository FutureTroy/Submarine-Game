using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using System.Timers;
using System.Windows.Media.Imaging;

namespace SubMarine_Subs
{
    /// <summary>
    /// Interaction logic for SubMarine_.xaml
    /// </summary>


    public partial class SubMarine_ : Window
    {
        static int num = 1;
        /*Player N;
        public SubMarine_(Player N)
        */
        int sandwichIndex = 0;
        int finishedSubsCounter = 0;

        string[] sandwiches = { "The Yellow Submarine", "Shrimp Po'Boy", "YellowWittz Special", "Lemon Pepper Tilapia Sandwich" };
        static string response;

        static SpicyResponse spicy = new SpicyResponse();
        static ExoticResponse exotic = new ExoticResponse();
        static FillingResponse filling = new FillingResponse();
        static TastyResponse tasty = new TastyResponse();

        DispatcherTimer _timer;
        TimeSpan _time;

        static List<string> yellowingredients = new List<string>();
        static List<string> shrimpingredients = new List<string>();
        static List<string> specialingredients = new List<string>();
        static List<string> tilapiaingredients = new List<string>();
        List<string> currentingredients = new List<string>();
        ShrimpSandwich shrimpSandwich = new ShrimpSandwich();
        YellowSandwich yellowSandwich = new YellowSandwich();
        YellowWittzSandwich yellowWittzSandwich = new YellowWittzSandwich();
        CatfishSandwich catfishSandwich = new CatfishSandwich();
        Iterator shrimpSandwichIterator;
        Iterator yellowSandwichIterator;
        Iterator yellowWittzSandwichIterator;
        Iterator catfishSandwichIterator;
        Ingredient ingredient;

        


        public SubMarine_()
        {
            InitializeComponent();


            TimerSeclbl.Content = "10";

            InitializeComponent();

            finishedSubslbl.Content = finishedSubsCounter.ToString();

            yellowingredients.Add("Lettuce");
            yellowingredients.Add("Breaded Cod");
            yellowingredients.Add("Yellow Peppers");
            yellowingredients.Add("Sea Salt");
            yellowingredients.Add("White Bread");

            shrimpingredients.Add("Shrimp");
            shrimpingredients.Add("Lettuce");
            shrimpingredients.Add("Onions");
            shrimpingredients.Add("Tartar Sauce");
            shrimpingredients.Add("Wheat Bread");

            specialingredients.Add("Lettuce");
            specialingredients.Add("Sea Salt");
            specialingredients.Add("Crawfish");
            specialingredients.Add("Tomato");
            specialingredients.Add("White Bread");

            tilapiaingredients.Add("Lemon Tilapia");
            tilapiaingredients.Add("Lettuce");
            tilapiaingredients.Add("Tartar Sauce");
            tilapiaingredients.Add("Yellow Peppers");
            tilapiaingredients.Add("Wheat Bread");

            //amount of time on the timer
            _time = TimeSpan.FromSeconds(60);

            //actual timer mechanism
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                TimerSeclbl.Content = _time.ToString("c");
                if (_time == TimeSpan.Zero)
                {
                    _timer.Stop();
                    string copyLabel;

                    copyLabel = finishedSubslbl.Content.ToString();
                    GameOver o = new GameOver(copyLabel);
                    o.Show();
                    this.Close();
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();
            spicy.respond();

            DataContext = this;
           // ImageUri = "pack://application:,,,/Resources/BottomBun.png";
           

        }

        int mins, secs;
        int stepcount;

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int timeSeconds = 60;
            _time = TimeSpan.FromSeconds(timeSeconds);
            _timer.Start();
        }


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            TimerSeclbl.Content = DateTime.Now.ToLongTimeString();
        }
        private void AddIngredient(object sender, RoutedEventArgs e)
        {

            stepcount = 5;


        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Threading.DispatcherTimer dispTimer = new System.Windows.Threading.DispatcherTimer();
            dispTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispTimer.Interval = new TimeSpan(0, 5, 0);
            dispTimer.Start();
        }





        class Order : Subject
        {
            private List<Observer> observers;
            private String name, status;

            public Order(String name)
            {
                this.name = name;
                observers = new List<Observer>();
            }

            public void setStatus(String status)
            {
                this.status = status;
                notifyObserver();
            }

            public void register(Observer o)
            {
                observers.Add(o);
            }

            public void unregister(Observer o)
            {
                observers.Remove(o);
            }

            public void notifyObserver()
            {
                foreach (Observer observer in observers)
                {
                    observer.update(name, status);
                }
            }
        }


        class Customer : Observer
        {
            private String customername, ordername, status;
            private Subject order;

            public Customer(String customername, Subject order)
            {
                this.customername = customername;
                this.order = order;
                order.register(this);
            }

            public void update(String ordername, String status)
            {
                this.ordername = ordername;
                this.status = status;

            }

            public void showStatus()
            {
                if (status.Equals("Ready"))
                {
                    MessageBox.Show("Customer number: " + customername + "\nOrder number: " + ordername + "\nStatus: " + status + "\n" + response);
                }
                else
                {
                    MessageBox.Show("Customer number: " + customername + "\nOrder number: " + ordername + "\nStatus: " + status);
                }
            }
        }


        interface Subject
        {
            void register(Observer o);
            void unregister(Observer o);
            void notifyObserver();
        }

        interface Observer
        {
            void update(String name, String location);
        }


        private void OrderReadyBtn_Click(object sender, RoutedEventArgs e)
        {
            Order order1 = new Order(num.ToString());
            Customer customer1 = new Customer(num.ToString(), order1);
            var current = string.Join(Environment.NewLine, currentingredients);

            if (sandwiches[sandwichIndex].Equals("The Yellow Submarine"))
            {
                var yellow = string.Join(Environment.NewLine, yellowingredients);
                if (current.Equals(yellow))
                {
                    order1.setStatus("Ready");
                    customer1.showStatus();
                    num++;
                    finishedSubsCounter++;
                    finishedSubslbl.Content = finishedSubsCounter.ToString();
                }
                else
                {
                    order1.setStatus("Not Ready");
                    customer1.showStatus();
                }


            }

            else if (sandwiches[sandwichIndex].Equals("Shrimp Po'Boy"))
            {
                var shrimp = string.Join(Environment.NewLine, shrimpingredients);
                if (current.Equals(shrimp))
                {
                    order1.setStatus("Ready");
                    customer1.showStatus();
                    num++;
                    finishedSubsCounter++;
                    finishedSubslbl.Content = finishedSubsCounter.ToString();
                }
                else
                {
                    order1.setStatus("Not Ready");
                    customer1.showStatus();
                }

            }

            else if (sandwiches[sandwichIndex].Equals("YellowWittz Special"))
            {
                var special = string.Join(Environment.NewLine, specialingredients);
                if (current.Equals(special))
                {
                    order1.setStatus("Ready");
                    customer1.showStatus();
                    num++;
                    finishedSubsCounter++;
                    finishedSubslbl.Content = finishedSubsCounter.ToString();
                }
                else
                {
                    order1.setStatus("Not Ready");
                    customer1.showStatus();
                }
            }

            else if (sandwiches[sandwichIndex].Equals("Lemon Pepper Tilapia Sandwich"))
            {
                var tilapia = string.Join(Environment.NewLine, tilapiaingredients);
                if (current.Equals(tilapia))
                {
                    order1.setStatus("Ready");
                    customer1.showStatus();
                    num++;
                    finishedSubsCounter++;
                    finishedSubslbl.Content = finishedSubsCounter.ToString();
                }
                else
                {
                    order1.setStatus("Not Ready");
                    customer1.showStatus();
                }
            }
        }


        private void tilapiaBtn_Click(object sender, RoutedEventArgs e)
        {
            currentingredients.Add("Lemon Tilapia");
            lemonTilapia.Visibility = System.Windows.Visibility.Visible;
            ProgBar.Value = ProgBar.Value + 100;
            stepcount = 4;
            tilapiaBtn.Visibility = System.Windows.Visibility.Hidden;
        }

        private void YPeppersBtn_Click(object sender, RoutedEventArgs e)
        {
            currentingredients.Add("Yellow Peppers");
            YPeppers.Visibility = System.Windows.Visibility.Visible;
            ProgBar.Value = ProgBar.Value + 100;
            stepcount = 3;
            YPeppersBtn.Visibility = System.Windows.Visibility.Hidden;
        }

        private void bCodBtn_Click(object sender, RoutedEventArgs e)
        {
            currentingredients.Add("Breaded Cod");
            BCod.Visibility = System.Windows.Visibility.Visible;
            ProgBar.Value = ProgBar.Value + 100;
            stepcount = 2;
            bCodBtn.Visibility = System.Windows.Visibility.Hidden;
        }
        private void lettuceBtn_Click(object sender, RoutedEventArgs e)
        {
            currentingredients.Add("Lettuce");
            lettuce.Visibility = System.Windows.Visibility.Visible;
            ProgBar.Value = ProgBar.Value + 100;
            stepcount = 1;
            lettuceBtn.Visibility = System.Windows.Visibility.Hidden;
        }

        private void SeaSaltBtn_Click(object sender, RoutedEventArgs e)
        {
            currentingredients.Add("Sea Salt");
            salt.Visibility = System.Windows.Visibility.Visible;
            ProgBar.Value = ProgBar.Value + 100;
            SeaSaltBtn.Visibility = System.Windows.Visibility.Hidden;
        }

        private void TomatoBtn_Click(object sender, RoutedEventArgs e)
        {
            currentingredients.Add("Tomato");
            tomato.Visibility = System.Windows.Visibility.Visible;
            ProgBar.Value = ProgBar.Value + 100;
            TomatoBtn.Visibility = System.Windows.Visibility.Hidden;
        }

        private void OnionsBtn_Click(object sender, RoutedEventArgs e)
        {
            currentingredients.Add("Onions");
            Onions.Visibility = System.Windows.Visibility.Visible;
            ProgBar.Value = ProgBar.Value + 100;
            OnionBtn.Visibility = System.Windows.Visibility.Hidden;
        }

        private void ShrimpBtn_Click(object sender, RoutedEventArgs e)
        {
            currentingredients.Add("Shrimp");
            Shrimp.Visibility = System.Windows.Visibility.Visible;
            ProgBar.Value = ProgBar.Value + 100;
            ShrimpBtn.Visibility = System.Windows.Visibility.Hidden;
        }

        private void CrawfishBtn_Click(object sender, RoutedEventArgs e)
        {
            currentingredients.Add("Crawfish");
            crawfish.Visibility = System.Windows.Visibility.Visible;
            ProgBar.Value = ProgBar.Value + 100;
            CrawfishBtn.Visibility = System.Windows.Visibility.Hidden;
        }

        private void TartarBtn_Click(object sender, RoutedEventArgs e)
        {
            currentingredients.Add("Tartar Sauce");
            Tartarsauce.Visibility = System.Windows.Visibility.Visible;
            ProgBar.Value = ProgBar.Value + 100;
            TartarBtn.Visibility = System.Windows.Visibility.Hidden;
        }

        private void WhiteBtn_Click(object sender, RoutedEventArgs e)
        {
            currentingredients.Add("White Bread");
            BunTop.Visibility = System.Windows.Visibility.Visible;
            ProgBar.Value = ProgBar.Value + 100;
            WhiteBtn.Visibility = System.Windows.Visibility.Hidden;
        }

        private void WheatBtn_Click(object sender, RoutedEventArgs e)
        {
            currentingredients.Add("Wheat Bread");
            wheatTop.Visibility = System.Windows.Visibility.Visible;
            ProgBar.Value = ProgBar.Value + 100;
            WheatBtn.Visibility = System.Windows.Visibility.Hidden;
        }

        private void undoBtn_Click(object sender, RoutedEventArgs e)
        {
            currentingredients.Clear();
            ProgBar.Value = 0;
            resetSandwich();

            if (stepcount == 1)
            {
                if (lettuce.Visibility == System.Windows.Visibility.Visible)
                {
                    lettuce.Visibility = System.Windows.Visibility.Hidden;
                }
            }

            if (stepcount == 2)
            {
                if (BCod.Visibility == System.Windows.Visibility.Visible)
                {
                    BCod.Visibility = System.Windows.Visibility.Hidden;
                }
            }

            if (stepcount == 3)
            {
                if (YPeppers.Visibility == System.Windows.Visibility.Visible)
                {
                    YPeppers.Visibility = System.Windows.Visibility.Hidden;
                }
            }

            if (stepcount == 4)
            {
                if (lemonTilapia.Visibility == System.Windows.Visibility.Visible)
                {
                    lemonTilapia.Visibility = System.Windows.Visibility.Hidden;
                }
            }

            if (stepcount == 5)
            {
                if (BunTop.Visibility == System.Windows.Visibility.Visible)
                {
                    BunTop.Visibility = System.Windows.Visibility.Hidden;
                }
            }
            stepcount = stepcount--;
        }

        private void skipBtn_Click(object sender, RoutedEventArgs e)
        {
            ProgBar.Value = 0;
            var yellowlist = string.Join(Environment.NewLine, yellowingredients);
            var shrimplist = string.Join(Environment.NewLine, shrimpingredients);
            var speciallist = string.Join(Environment.NewLine, specialingredients);
            var tilapialist = string.Join(Environment.NewLine, tilapiaingredients);

            currentingredients.Clear();
            sandwichIndex++;
            if (sandwichIndex == 4)
            {
                sandwichIndex = 0;
                yellowSandwichIterator = null;
                shrimpSandwichIterator = null;
                yellowWittzSandwichIterator = null;
                catfishSandwichIterator = null;
            }

            if (sandwiches[sandwichIndex].Equals("The Yellow Submarine"))
            {
                sandwichlbl_Copy.Content = yellowlist;
                spicy.respond();
                sandwichbottom.Source = new BitmapImage(new Uri("pack://application:,,,/SubMarine_Subs;component/Resources/BottomBun.png"));
            }
            if (sandwiches[sandwichIndex].Equals("Shrimp Po'Boy"))
            {
                sandwichlbl_Copy.Content = shrimplist;
                filling.respond();
                sandwichbottom.Source = new BitmapImage(new Uri("pack://application:,,,/SubMarine_Subs;component/Resources/wheatBottom.png"));
            }

            if (sandwiches[sandwichIndex].Equals("YellowWittz Special"))
            {
                sandwichlbl_Copy.Content = speciallist;
                exotic.respond();
                sandwichbottom.Source = new BitmapImage(new Uri("pack://application:,,,/SubMarine_Subs;component/Resources/BottomBun.png"));
            }

            if (sandwiches[sandwichIndex].Equals("Lemon Pepper Tilapia Sandwich"))
            {
                sandwichlbl_Copy.Content = tilapialist;
                tasty.respond();
                sandwichbottom.Source = new BitmapImage(new Uri("pack://application:,,,/SubMarine_Subs;component/Resources/wheatBottom.png"));
            }



            sandwichlbl.Content = sandwiches[sandwichIndex];

            resetSandwich();

        }

        public void resetSandwich()
        {
            if (BunTop.Visibility == System.Windows.Visibility.Visible)
            {
                BunTop.Visibility = System.Windows.Visibility.Hidden;
            }

            if (lettuce.Visibility == System.Windows.Visibility.Visible)
            {
                lettuce.Visibility = System.Windows.Visibility.Hidden;
            }

            if (BCod.Visibility == System.Windows.Visibility.Visible)
            {
                BCod.Visibility = System.Windows.Visibility.Hidden;
            }

            if (YPeppers.Visibility == System.Windows.Visibility.Visible)
            {
                YPeppers.Visibility = System.Windows.Visibility.Hidden;
            }

            if (lemonTilapia.Visibility == System.Windows.Visibility.Visible)
            {
                lemonTilapia.Visibility = System.Windows.Visibility.Hidden;
            }

            if (Onions.Visibility == System.Windows.Visibility.Visible)
            {
                Onions.Visibility = System.Windows.Visibility.Hidden;
            }
            if (Tartarsauce.Visibility == System.Windows.Visibility.Visible)
            {
                Tartarsauce.Visibility = System.Windows.Visibility.Hidden;
            }
            if (Shrimp.Visibility == System.Windows.Visibility.Visible)
            {
                Shrimp.Visibility = System.Windows.Visibility.Hidden;
            }
            if (wheatTop.Visibility == System.Windows.Visibility.Visible)
            {
                wheatTop.Visibility = System.Windows.Visibility.Hidden;
            }
            if (salt.Visibility == System.Windows.Visibility.Visible)
            {
                salt.Visibility = System.Windows.Visibility.Hidden;
            }
            if (tomato.Visibility == System.Windows.Visibility.Visible)
            {
                tomato.Visibility = System.Windows.Visibility.Hidden;
            }
            if (crawfish.Visibility == System.Windows.Visibility.Visible)
            {
                crawfish.Visibility = System.Windows.Visibility.Hidden;
            }
            WheatBtn.Visibility = System.Windows.Visibility.Visible;
            OnionBtn.Visibility = System.Windows.Visibility.Visible;
            tilapiaBtn.Visibility = System.Windows.Visibility.Visible;
            SeaSaltBtn.Visibility = System.Windows.Visibility.Visible;
            WhiteBtn.Visibility = System.Windows.Visibility.Visible;
            TartarBtn.Visibility = System.Windows.Visibility.Visible;
            ShrimpBtn.Visibility = System.Windows.Visibility.Visible;
            lettuceBtn.Visibility = System.Windows.Visibility.Visible;
            bCodBtn.Visibility = System.Windows.Visibility.Visible;
            CrawfishBtn.Visibility = System.Windows.Visibility.Visible;
            ShrimpBtn.Visibility = System.Windows.Visibility.Visible;
            TomatoBtn.Visibility = System.Windows.Visibility.Visible;
            YPeppersBtn.Visibility = System.Windows.Visibility.Visible;
        }



        abstract class CustomerResponse
        {

            public void respond()
            {
                responding();
            }

            public abstract void responding();
        }

        class SpicyResponse : CustomerResponse
        {
            public override void responding()
            {
                response = "Wow! This sandwich sure is spicy!";
            }
        }

        class ExoticResponse : CustomerResponse
        {
            public override void responding()
            {
                response = "What an exotic sandwich! I'll be sure to tell my friends!";
            }
        }

        class FillingResponse : CustomerResponse
        {
            public override void responding()
            {
                response = "Good God... I'm so full...";
            }
        }

        class TastyResponse : CustomerResponse
        {
            public override void responding()
            {
                response = "Jeepers! That was delicious!";
            }
        }






        // Kenneth - Revision from this point on
        class Ingredient
        {
            private String name;

            public Ingredient(String name)
            {
                this.name = name;
            }

            public String getName()
            {
                return name;
            }
        }

        interface Sandwich
        {
            Iterator createIterator();
        }

        class YellowSandwich : Sandwich
        {
            static int MAX_INGREDIENTS = 5;
            int numberOfIngredients = 0;
            Ingredient[] ingredients;

            public YellowSandwich()
            {
                ingredients = new Ingredient[MAX_INGREDIENTS];

                addIngredient("Lettuce");
                addIngredient("Breaded Cod");
                addIngredient("Yellow Peppers");
                addIngredient("Lemon Tilapia");
                addIngredient("White Bread");

            }

            public void addIngredient(String name)
            {
                Ingredient ingredientItem = new Ingredient(name);
                ingredients[numberOfIngredients] = ingredientItem;
                numberOfIngredients += 1;
            }

            public Ingredient[] getIngredients()
            {
                return ingredients;
            }

            public Iterator createIterator()
            {
                return new SandwichIterator(ingredients);
            }
        }

        class ShrimpSandwich : Sandwich
        {
            static int MAX_INGREDIENTS = 5;
            int numberOfIngredients = 0;
            Ingredient[] ingredients;

            public ShrimpSandwich()
            {
                ingredients = new Ingredient[MAX_INGREDIENTS];

                addIngredient("Shrimp");
                addIngredient("Lettuce");
                addIngredient("Onions");
                addIngredient("Tartar Sauce");
                addIngredient("Wheat Bread");
            }

            public void addIngredient(String name)
            {
                Ingredient ingredientItem = new Ingredient(name);
                ingredients[numberOfIngredients] = ingredientItem;
                numberOfIngredients += 1;
            }

            public Ingredient[] getIngredients()
            {
                return ingredients;
            }

            public Iterator createIterator()
            {
                return new SandwichIterator(ingredients);
            }
        }

        class YellowWittzSandwich : Sandwich
        {
            static int MAX_INGREDIENTS = 5;
            int numberOfIngredients = 0;
            Ingredient[] ingredients;

            public YellowWittzSandwich()
            {
                ingredients = new Ingredient[MAX_INGREDIENTS];

                addIngredient("Lettuce");
                addIngredient("Tartar Sauce");
                addIngredient("Crawfish");
                addIngredient("Tomato");
                addIngredient("White Bread");
            }

            public void addIngredient(String name)
            {
                Ingredient ingredientItem = new Ingredient(name);
                ingredients[numberOfIngredients] = ingredientItem;
                numberOfIngredients += 1;
            }

            public Ingredient[] getIngredients()
            {
                return ingredients;
            }

            public Iterator createIterator()
            {
                return new SandwichIterator(ingredients);
            }
        }

        class CatfishSandwich : Sandwich
        {
            static int MAX_INGREDIENTS = 5;
            int numberOfIngredients = 0;
            Ingredient[] ingredients;

            public CatfishSandwich()
            {
                ingredients = new Ingredient[MAX_INGREDIENTS];

                addIngredient("Grilled Catfish");
                addIngredient("Lettuce");
                addIngredient("Tartar Sauce");
                addIngredient("Tomato");
                addIngredient("Wheat Bread");
            }

            public void addIngredient(String name)
            {
                Ingredient ingredientItem = new Ingredient(name);
                ingredients[numberOfIngredients] = ingredientItem;
                numberOfIngredients += 1;
            }

            public Ingredient[] getIngredients()
            {
                return ingredients;
            }

            public Iterator createIterator()
            {
                return new SandwichIterator(ingredients);
            }
        }

        interface Iterator
        {
            Ingredient next();
            bool hasNext();
        }

        class SandwichIterator : Iterator
        {
            Ingredient[] ingredients;
            int position = 0;

            public SandwichIterator(Ingredient[] ingredients)
            {
                this.ingredients = ingredients;
            }

            public Ingredient next()
            {
                Ingredient ingredient = ingredients[position];
                position += 1;
                return ingredient;
            }

            public bool hasNext()
            {
                if (position >= ingredients.Length || ingredients[position] == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        // Needs more work
        private void restockIngredientsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sandwichIndex == 0)
            {
                if (yellowSandwichIterator == null)
                {
                    yellowSandwichIterator = yellowSandwich.createIterator();
                    ingredient = yellowSandwichIterator.next();
                }
                ingredient = yellowSandwichIterator.next();
                sandwichlbl_Copy.Content = ingredient.getName();

                if (!yellowSandwichIterator.hasNext())
                {
                    sandwichIndex++;
                }
            }
            else if (sandwichIndex == 1)
            {
                if (shrimpSandwichIterator == null)
                {
                    shrimpSandwichIterator = shrimpSandwich.createIterator();
                }
                ingredient = shrimpSandwichIterator.next();
                sandwichlbl_Copy.Content = ingredient.getName();

                if (!shrimpSandwichIterator.hasNext())
                {
                    sandwichIndex++;
                }
            }
            else if (sandwichIndex == 2)
            {
                if (yellowWittzSandwichIterator == null)
                {
                    yellowWittzSandwichIterator = yellowWittzSandwich.createIterator();
                }
                ingredient = yellowWittzSandwichIterator.next();
                sandwichlbl_Copy.Content = ingredient.getName();

                if (!yellowWittzSandwichIterator.hasNext())
                {
                    sandwichIndex++;
                }
            }
            else
            {
                if (catfishSandwichIterator == null)
                {
                    catfishSandwichIterator = catfishSandwich.createIterator();
                }
                ingredient = catfishSandwichIterator.next();
                sandwichlbl_Copy.Content = ingredient.getName();

                if (!catfishSandwichIterator.hasNext())
                {
                    sandwichIndex++;
                }
            }
        }

        private void Switch_Click(object sender, RoutedEventArgs e)
        {
            sandwichbottom.Source = new BitmapImage(new Uri("pack://application:,,,/SubMarine_Subs;component/Resources/wheatBottom.png"));
        }

    }
}