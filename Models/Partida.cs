 static class Partida
{
     static public string palabra { get; private set; }
     static public List<char> palabraActual { get; private set; }
     static public List<char> letrasFallidas { get; private set; }
     static public int cantIntentos { get; private set; }
     static public bool partidaGanada { get; private set; }  
    static Partida(){
        palabra = "";
        palabraActual = new List<char>();
        letrasFallidas = new List<char>();

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


    static private char convertirChar(char letra){
        string letraN = letra+"";
        letraN = letraN.ToUpper();
        char letraNueva = letraN[0];
        return letraNueva;
    }

    static public bool siSeUso(char letra){
        bool siSeUso= false;
        char letraNueva = convertirChar(letra);
        if(palabraActual.Contains(letraNueva) || letrasFallidas.Contains(letraNueva))
        {
            siSeUso = true;
        }
        return siSeUso;
    }

    static public bool esCorrecta (char letra)
    {
        bool esCorrecta = false;
        char letraNueva = convertirChar(letra);
        esCorrecta = palabra.Contains(letraNueva);
        if(esCorrecta){
              for(int i=0;i < palabra.Count(); i++){
            if(palabra[i] == letraNueva){
                palabraActual[i] = letraNueva;
            }
        }
        }else
        {
                letrasFallidas.Add(letra);
                cantIntentos--;
        }
        return esCorrecta;
    }
    static public bool encontroLaPalabra(string palabraArriesgada){
        bool partidaGanada = false;
        if(palabraArriesgada == palabra){
            partidaGanada = true;
        }
        return partidaGanada;
    }

}