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
     static public void crearPartida(string Palabra)
    {
        palabra = Palabra.ToUpper();

        foreach (char letra in palabra)
        {
            palabraActual.Add('_');
        }
        cantIntentos = 6;
        partidaGanada = false;
    }

    static public bool siSeUso(char letra){
        bool siSeUso= false;
        if(palabraActual.Contains(letra))
        {
            siSeUso = true;
        }
        return siSeUso;
    }
    static public bool esCorrecta (char letra)
    {
        bool esCorrecta = false;
        for (int i = 0; i < palabra.Length; i++)
        {
            if (palabra[i] == letra)
            {
                palabraActual[i] = letra;
                esCorrecta = true;
            }
         }
        if (!esCorrecta)
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
    static public List<char>  devolverPalabraActual(){
        return palabraActual;
    }

}