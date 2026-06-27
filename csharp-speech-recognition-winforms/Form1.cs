namespace csharp_speech_recognition_winforms
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Speech.Recognition;
    using System.Text;
    using System.Globalization;

    public partial class Form1 : Form
    {

        private SpeechRecognitionEngine recEngine;

        // La seguent estructura de dades serveix per emmagatzemar la string amb la paraula i la string amb l'ordre corresponent.
        private Dictionary<string, string> ordreAccions = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();

            // Informacio de depuracio: Mostrem els motors de reconeixement de veu per la consola per confirmar que existeix el es-ES
            foreach (RecognizerInfo ri in SpeechRecognitionEngine.InstalledRecognizers())
            {
                Console.WriteLine($"Found: {ri.Culture.Name} - {ri.Description}");
            }

            // Creem el motor que ens interessa
            recEngine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("es-ES"));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                // Cada vegada que s'inicia el reconeixement cal eliminar anteriors ordres i fer la lectura de les noves.
                ordreAccions.Clear();
                Choices ordres = new Choices();

                for (int i = 0; i < 5; i++)
                {
                    string paraula = this.Controls["txtWord" + i].Text.Trim();
                    string tecla = this.Controls["txtKey" + i].Text.Trim();

                    if (!string.IsNullOrEmpty(paraula) && !string.IsNullOrEmpty(tecla))
                    {
                        // Es poden enviar tecles de modificadors afegint símbols al final

                        StringBuilder ordreCompleta = new StringBuilder();

                        // Mirem si hi ha modificadors. En cas d'haver-hi, es van afegint tots.
                        if (((CheckBox)this.Controls["chkShift" + i]).Checked) ordreCompleta.Append("+");
                        if (((CheckBox)this.Controls["chkCtrl" + i]).Checked) ordreCompleta.Append("^");
                        if (((CheckBox)this.Controls["chkAlt" + i]).Checked) ordreCompleta.Append("%");

                        // Afegim la tecla
                        ordreCompleta.Append(tecla);

                        ordres.Add(paraula);
                        ordreAccions[paraula] = ordreCompleta.ToString();
                    }
                }

                // Sempre volem l'ordre "cerrar"
                ordres.Add("cerrar");

                // Informació de depuracio: Comprovem les ordres en consola
                foreach (var o in ordreAccions)
                {
                    Console.WriteLine(o.ToString());
                }

                // Construim l'objecte encarregat de gestionar l'idioma
                GrammarBuilder gBuilder = new GrammarBuilder();
                gBuilder.Culture = new CultureInfo("es-ES", false);

                // Afegim les ordres i ho passem al motor
                gBuilder.Append(ordres);
                recEngine.LoadGrammarAsync(new Grammar(gBuilder));

                // Definit el metode EventHandler que sera executat quan es reconegi la veu
                recEngine.SpeechRecognized += RecEngine_SpeechRecognized;
                // Engeguem
                recEngine.SetInputToDefaultAudioDevice();
                recEngine.RecognizeAsync(RecognizeMode.Multiple);

                // Detall menor per evitar iniciar quan ja s'iniciat
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Initialization Error: " + ex.Message);
            }
        }

        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            // Cada vegada que hi ha un reconeixement
            string paraula = e.Result.Text;

            // Mirem si cal tancar
            if (string.Equals(paraula, "cerrar"))
            {
                comprovarTancament();
            }

            // En cas contrari, obtenim i enviem l'ordre
            if (ordreAccions.TryGetValue(paraula, out string keyStroke))
            {
                SendKeys.SendWait(keyStroke);
            }
        }

        private void comprovarTancament()
        {

            // Preguntem a l'usuari si realment vol tancar l'aplicacio
            DialogResult result = MessageBox.Show(
                "Vols tancar l'aplicació?",
                "Confirmació",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Si clica si
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }


        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            // Parem
            recEngine.RecognizeAsyncStop();
            // Elimininem el EventHandler per evitar duplicitats si es torna a engegar
            recEngine.SpeechRecognized -= RecEngine_SpeechRecognized;

            // Retornem la UI a l'estat inicial
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

    }
}

