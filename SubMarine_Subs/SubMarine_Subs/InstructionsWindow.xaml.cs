using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SubMarine_Subs
{
    /// <summary>
    /// Interaction logic for InstructionsWindow.xaml
    /// </summary>
    public partial class InstructionsWindow : Window
    {
        InstructionsFactory ifInstance = InstructionsFactory.getInstructionsFactory();
        Instructions instructionsInstance;

        public InstructionsWindow()
        {
            InitializeComponent();
            Instructions_About.Text = " Welcome to SubMarine Sandwiches!\n\n To start playing, press \"Play!\" at the Main Menu \n\n You have 5 minutes to make your customer's sandwich in the \"Customer's Order\" window, you'll see the sandwich you're currently " +
                     "making along with the next ingredient you need to add. The \"Sandwich Status\" Progress bar shows you how close you are to completing the sandwich. Once you're done, click the \"Order Ready\" Button to submit the sandwich to the customers!" +
                     "\n\n Menu holds your best time and Player Name.";
            LanguageCBox.SelectedIndex = 0;
        }

        class InstructionsFactory
        {
            private static InstructionsFactory ifInstance;
            private Instructions instructions;

            private InstructionsFactory()
            {
            }

            public static InstructionsFactory getInstructionsFactory()
            {
                if (ifInstance == null)
                    ifInstance = new InstructionsFactory();
                return ifInstance;
            }

            public Instructions createInstructions(int type)
            {
                if (type == 1)
                { // 1 - English
                    instructions = new EnglishInstructions();
                }
                else if (type == 2)
                { // 2 - Spanish
                    instructions = new SpanishInstructions();
                }
                else
                { // 3 - French
                    instructions = new FrenchInstructions();
                }

                return instructions;
            }
        }

        abstract class Instructions
        {
            public String text;
            public abstract String getText();
        }

        class EnglishInstructions : Instructions
        {
            public EnglishInstructions()
            {
                this.text = " Welcome to SubMarine Sandwiches!\n\n To start playing, press \"Play!\" at the Main Menu \n\n You have 5 minutes to make your customer's sandwich in the \"Customer's Order\" window, you'll see the sandwich you're currently " +
                     "making along with the next ingredient you need to add. The \"Sandwich Status\" Progress bar shows you how close you are to completing the sandwich. Once you're done, click the \"Order Ready\" Button to submit the sandwich to the customers!" +
                     "\n\n Menu holds your best time and Player Name.";
            }

            public override String getText()
            {
                return text;
            }
        }

        class SpanishInstructions : Instructions
        {
            public SpanishInstructions()
            {
                this.text = " Bienvenido a emparedados submarinos!\n\n Para comenzar a jugar, presiona \"Play!\" en el menú principal \n\n Tienes 5 minutoes para hacer sándwich de su cliente en la ventana \"Customer's Order\", verás el sándwich que estás haciendo " +
                     "junto con el siguiente ingrediente es necesario agregar. El \"Sandwich Status\" le barra de progreso muestra lo cerca que estás de completar el sándwich. Una vez que haya terminado, haga click en el botón \"Order Ready\" para enviar el sándwich al cliente!" +
                     "\n\n Menú tiene su mejor momento y el nombre del jugador.";
            }

            public override String getText()
            {
                return text;
            }
        }

        class FrenchInstructions : Instructions
        {
            public FrenchInstructions()
            {
                this.text = " Bienvenue à sandwichs sous-marins!\n\n Pour commencer à jouer, appuyez sur \"Play!\" dans le menu principal \n\nVous avez 5 minutes pour faire le sandwich de votre client dans l \"Ordre du Client\" fenêtre, vous verrez le sandwich vous êtes " +
                    "actuellement faire avec le prochain ingrédient que vous devez ajouter.Le \"Sandwich Etat\" barre de progression vous montre comment vous êtes proche de l'achèvement du sandwich. Une fois que vous avez terminé, cliquez sur le bouton \"Commander Prêt\" à " +
                    "soumettre le sandwich au client! \n\n Menu détient votre meilleur temps et le nom du joueur.";
            }

            public override String getText()
            {
                return text;
            }
        }

        private void ComboBoxItem_Selected_ENG(object sender, RoutedEventArgs e)
        {
            instructionsInstance = ifInstance.createInstructions(1);
            Instructions_About.Text = instructionsInstance.getText();
        }

        private void ComboBoxItem_Selected_SPN(object sender, RoutedEventArgs e)
        {
            instructionsInstance = ifInstance.createInstructions(2);
            Instructions_About.Text = instructionsInstance.getText();
        }

        private void ComboBoxItem_Selected_FRN(object sender, RoutedEventArgs e)
        {
            instructionsInstance = ifInstance.createInstructions(3);
            Instructions_About.Text = instructionsInstance.getText();
        }

        private void ComboBoxItem_Selected_None(object sender, RoutedEventArgs e)
        {
        }

        private void InstructionsCloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}