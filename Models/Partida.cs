static class Partida
{
    static public string palabra { get; private set; }
    static public List<char> palabraActual { get; private set; }
    static public List<char> letrasFallidas { get; private set; }
    static public int cantIntentos { get; private set; }
    static public bool partidaGanada { get; private set; }
    static public List<string> listaPalabras { get; set; }
    static Partida()
    {
        palabra = "";
        palabraActual = new List<char>();
        letrasFallidas = new List<char>();
        listaPalabras = new List<string>();
        agregarPalabras();

    }
    static private void agregarPalabras()
    {
        listaPalabras.Add("Guitarra");
        listaPalabras.Add("Arbol");
        listaPalabras.Add("Perro");
        listaPalabras.Add("Arcoiris");
        listaPalabras.Add("Magdalena");
        listaPalabras.Add("Tutuca");
        listaPalabras.Add("Cifrado");
        listaPalabras.Add("Puerta");
        listaPalabras.Add("Bioingenieria");
        listaPalabras.Add("Desarollo");
        listaPalabras.Add("Conexion");
        listaPalabras.Add("Rapidez");
        listaPalabras.Add("Velocidad");
        listaPalabras.Add("Bowling");
    }

    static public string elegirPalabra()
    {
        Random rndnum = new Random();
        int num = rndnum.Next(1, 14);
        return listaPalabras[num];
    }
    static public void crearPartida(string PalabraNueva)
    {

        palabra = PalabraNueva.ToUpper();
        palabraActual.Clear();
        foreach (char letra in palabra)
        {
            palabraActual.Add('_');
        }
        cantIntentos = 6;
        partidaGanada = false;
    }


    static private char convertirChar(char letra)
    {
        string letraN = letra + "";
        letraN = letraN.ToUpper();
        char letraNueva = letraN[0];
        return letraNueva;
    }

    static public bool siSeUso(char letra)
    {
        bool siSeUso = false;
        char letraNueva = convertirChar(letra);
        if (palabraActual.Contains(letraNueva) || letrasFallidas.Contains(letraNueva))
        {
            siSeUso = true;
        }
        return siSeUso;
    }

    static public bool esCorrecta(char letra)
    {
        bool esCorrecta = false;
        char letraNueva = convertirChar(letra);
        esCorrecta = palabra.Contains(letraNueva);
        if (esCorrecta)
        {
            for (int i = 0; i < palabra.Count(); i++)
            {
                if (palabra[i] == letraNueva)
                {
                    palabraActual[i] = letraNueva;
                }

                if (string.Join("", palabraActual) == palabra)
                {
                    partidaGanada = true;
                }
            }
        }
        else
        {
            letrasFallidas.Add(letra);
            cantIntentos--;
        }
        return esCorrecta;
    }
    static public bool encontroLaPalabra(string palabraArriesgada)
    {
        if (palabraArriesgada.ToUpper() == palabra)
        {
            partidaGanada = true;
        }
        return partidaGanada;
    }

    static public void ReiniciarJuego()
    {
        cantIntentos = 6;
        palabraActual.Clear();
        letrasFallidas.Clear();
        partidaGanada = false;
        palabra = "";

    }

}