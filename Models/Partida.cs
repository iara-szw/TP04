 static class Partida
{
     static public string palabra { get; private set; }
     static public List<char> palabraActual { get; private set; }
     static public List<char> letrasFallidas { get; private set; }
     static public int cantIntentos { get; private set; }

     static public void crearPartida(string Palabra)
    {
        palabra = Palabra.ToUpper();
        palabraActual = new List<char>();
        letrasFallidas = new List<char>();
        foreach (char letra in palabra)
        {
            palabraActual.Add('_');
        }
        cantIntentos = 6;
    }

    static public bool siSeUso(char letra){
        bool siSeUso= false;
        siSeUso = buscarLetra(letra,palabraActual);
        if(!siSeUso)
        {
            siSeUso = buscarLetra(letra,letrasFallidas);
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
        bool encontrada = false;
        if(palabraArriesgada == palabra){
            encontrada = true;
        }
        return encontrada;
    }
    static public bool buscarLetra(char letra, List<char> listaABuscar){
        bool seEncontro= false;
        int i = 0;
        while(!seEncontro && i<listaABuscar.Count()){
           if(listaABuscar[i] == letra){
            seEncontro=true;
           }else{i++;}
        }
        return seEncontro;
    }
    static public List<char>  devolverPalabraActual(){
        return palabraActual;
    }

}