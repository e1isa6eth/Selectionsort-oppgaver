
using System.Reflection.Emit;

//Jeg  skrev ned koden i dot net playground og limte de inn her, det er ikke veldig ryddig, men jeg fant ikke en annen mate a vise det frem pa. 
//sa hvis du limer oppgavene en og en inn i dotnet fiddle skal de funke


//OPPGAVE 1 
//etter 5 iterasjoner: 3 4 3 6 7 19 21 23 10 14 15 11 16 17 8
///etter 7 iterasjoner: 3 4 3 6 7 8 10 23 21 14 15 11 16 17 19 


//OPPGAVE 2
//3 iterasjoner med de støsrte nummerene bakerst 15 8 17 16 5 6 7 4 10 14 3 11 19 21 23


//OPPGAVE 3
public class Tabell
{

    static void Main()
    {
        int[] a = { 7, 5, 9, 2, 10, 4, 1, 8, 6, 3 };
        Utvalgssortering(a); //stigende sortering
        Snu(a); // tabellen snus max til min
        Skriv(a); //skriver ut
    }

    public static void Utvalgssortering(int[] a)
    {
        for (int i = 0; i < a.Length - 1; i++)
            Bytt(a, i, Min(a, i, a.Length)); // to hjelpemetoder
    }

    public static void Bytt(int[] a, int i, int j)
    {
        int temp = a[i];
        a[i] = a[j];
        a[j] = temp;
    }

    public static int Min(int[] a, int fra, int til)
    {
        int minIndex = fra;
        for (int i = fra + 1; i < til; i++)
        {
            if (a[i] < a[minIndex])
            {
                minIndex = i;
            }
        }
        return minIndex;
    }

    public static void Snu(int[] a)
    {
        int venstre = 0;
        int hoyre = a.Length - 1;

        while (venstre < hoyre)
        {
            Bytt(a, venstre, hoyre);
            venstre++;
            hoyre--;
        }
    }

    public static void Skriv(int[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            Console.Write(a[i] + " ");
        }
        Console.WriteLine();
    }
}


    //OPPGAVE 4
    
    static void Main()
    {
        int[] originalPermutasjon = LagTilfeldigArray(10000);

        int[] kopiPermutasjon1 = new int[originalPermutasjon.Length];
        Array.Copy(originalPermutasjon, kopiPermutasjon1, originalPermutasjon.Length);

        int[] kopiPermutasjon2 = new int[originalPermutasjon.Length];
        Array.Copy(originalPermutasjon, kopiPermutasjon2, originalPermutasjon.Length);

        long tidUtvalgssortering = MålTid(() => Tabell.Utvalgssortering(kopiPermutasjon1));

        long tidBoblesortering = MålTid(() => Tabell.Boblesortering(kopiPermutasjon2));

        Console.WriteLine("Tid brukt for utvalgssortering: " + tidUtvalgssortering + " ms");
        Console.WriteLine("Tid brukt for boblesortering: " + tidBoblesortering + " ms");
    }

    // Lag tilfeldig array
    static int[] LagTilfeldigArray(int lengde)
    {
        Random rand = new Random();
        int[] array = new int[lengde];

        for (int i = 0; i < lengde; i++)
        {
            array[i] = rand.Next(100000);
        }

        return array;
    }

    // Mål tiden for en gitt funksjon
    static long MålTid(Action funksjon)
    {
        var starttid = DateTime.Now;
        funksjon.Invoke();
        var sluttid = DateTime.Now;

        return (long)(sluttid - starttid).TotalMilliseconds;
    }
}

class Tabell
{
    public static void Utvalgssortering(int[] a)
    {
        for (int i = 0; i < a.Length - 1; i++)
        {
            int minIndex = i;5
            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[j] < a[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = a[i];
            a[i] = a[minIndex];
            a[minIndex] = temp;
        }
    }

    public static void Boblesortering(int[] a)
    {
        for (int n = a.Length; n > 1;)
        {
            int byttindeks = 0;
            for (int i = 1; i < n; i++)
            {
                if (a[i - 1] > a[i])
                {
                    Bytt(a, i - 1, i);
                    byttindeks = i;
                }
            }
            n = byttindeks;
        }
    }

    public static void Bytt(int[] a, int i, int j)
    {
        int temp = a[i];
        a[i] = a[j];
        a[j] = temp;
    }
}


//OPPGAVE 5
//som vi ser er uten hjelpemetider raskere enn med, har kanskje noe med overheaden a gjore.
//men hjelpemetodene skal gjore koden gjenbrukbart til fremtiden osv.

    static void Main()
{
    int[] array = randomarray(1000);


    long tidUtvalgssorteringMedhjelpemetoder = MålTid(() => selectionsort(array));

    long tidUtvalgssorteringUtenHjelpemetoder = MålTid(() => selectionsortsimple(array));

    Console.WriteLine("Tid brukt for utvalgssortering med hjelpemetoder: " + tidUtvalgssorteringMedhjelpemetoder+ " ms");
    Console.WriteLine("Tid brukt for utvalgssortering uten hjelpemetoder: " + tidUtvalgssorteringUtenHjelpemetoder + " ms");
}

static int[] randomarray(int lengde)
{
    Random rand = new Random();
    int[] array = new int[lengde];

    for (int i = 0; i < lengde; i++)
    {
        array[i] = rand.Next(100000);
    }

    return array;
}

static long MålTid(Action funksjon)
{
    var starttid = DateTime.Now;
    funksjon.Invoke();
    var sluttid = DateTime.Now;

    return (long)(sluttid - starttid).TotalMilliseconds;
}

static void selectionsort(int[] a)
{
    for (int i = 0; i < a.Length - 1; i++)
    {
        Bytt(a, i, Min(a, i, a.Length));
    }
}



static void selectionsortsimple(int[] a)
{
    for (int i = 0; i < a.Length - 1; i++)
    {
        int minIndex = i;
        for (int j = i + 1; j < a.Length; j++)
        {
            if (a[j] < a[minIndex])
            {
                minIndex = j;
            }
        }
        int temp = a[i];
        a[i] = a[minIndex];
        a[minIndex] = temp;
    }
}

// hjelpemetodene
static void Bytt(int[] a, int i, int j)
{
    int temp = a[i];
    a[i] = a[j];
    a[j] = temp;
}

static int Min(int[] a, int start, int slutt)
{
    int minIndex = start;
    for (int i = start + 1; i < slutt; i++)
    {
        if (a[i] < a[minIndex])
        {
            minIndex = i;
        }
    }
    return minIndex;
}



//OPPGAVE 6
//man sparer egentlig bare pa en operasjon, en leseoperasjon.

public static void selectionsortsimple2(int[] a)
{
    for (int i = 0; i < a.Length - 1; i++)
    {
        int m = i;             
        int minverdi = a[i]; 

        for (int j = i + 1; j < a.Length; j++)
        {
            if (a[j] < minverdi)
            {
                minverdi = a[j];  // ny minste verdi
                m = j;            // indeksen til ny minste verdi
            }
        }
        a[m] = a[i];
        a[i] = minverdi;
    }
}



//OPPGAVE 7

static void Main()
{
    int[] array = { 7, 2, 9, 1, 5, 3, 8, 4, 6 };

    omvendtselectionsort(array);

    Console.WriteLine(" ");
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write(array[i] + " ");
    }
}

static void omvendtselectionsort(int[] a)
{
    for (int i = a.Length - 1; i > 0; i--)
    {
        int maksIndex = i;
        int maksverdi = a[i];

        for (int j = i - 1; j >= 0; j--)
        {
            if (a[j] > maksverdi)
            {
                maksverdi = a[j];
                maksIndex = j;
            }
        }
        a[maksIndex] = a[i];
        a[i] = maksverdi;
    }
}



//OPPGAVE 8

static void Main()
{
    int[] array = { 7, 2, 9, 1, 5, 3, 8, 4, 6 };

    synkendeselectionsort(array);

    Console.WriteLine(" ");
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write(array[i] + " ");
    }
}

public static void synkendeselectionsort(int[] a)
{
    for (int i = 0; i < a.Length - 1; i++)
    {
        int minIndex = i;
        int minverdi = a[i];

        for (int j = i + 1; j < a.Length; j++)
        {
            if (a[j] > minverdi)
            {
                minverdi = a[j];
                minIndex = j;
            }
        }
        a[minIndex] = a[i];
        a[i] = minverdi;
    }
}
}


//OPPGAVE 9
 public static void Main()
{
    int[] array = { 7, 33, 2, 9, 1, 12, 5, 3, 8, 4, 0, 6 };

    // et spesifikt punkt index i arrayen
    selectionsort(array, 2, 6);

    Console.WriteLine(" ");
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write(array[i] + " ");
    }
}

public static void selectionsort(int[] a, int fra, int til)
{
    if (fra < 0 || til > a.Length || fra >= til)
    {
        Console.WriteLine("Ugyldig intervall!");
        return;
    }

    for (int i = fra; i < til - 1; i++)
    {
        int minIndex = i;
        int minverdi = a[i];

        for (int j = i + 1; j < til; j++)
        {
            if (a[j] < minverdi)
            {
                minverdi = a[j];
                minIndex = j;
            }
        }
        a[minIndex] = a[i];
        a[i] = minverdi;
    }

}



//OPPGAVE 10
//nei selectionsort er ikke en stabil algoritme, for sorteringen pa like elementer kan forandres ilopet av sorteringen.




//OPPGAVE 11

static void Main()
{
    for (int i = 0; i < 10; i++)
    {
        int[] a = GenererTilfeldigPermutasjon(10);
        Console.Write(Utvalgssortering(a) + " ");
    }
}

public static int Utvalgssortering(int[] a)
{
    int antallSelvbytter = 0;

    for (int i = 0; i < a.Length - 1; i++)
    {
        int m = Min(a, i, a.Length);  // posisjonen til den minste
        if (m != i)
        {
            Bytt(a, i, m);
        }
        else
        {
            antallSelvbytter++;
        }
    }

    return antallSelvbytter;
}

public static int Min(int[] a, int start, int slutt)
{
    int minIndex = start;
    for (int i = start + 1; i < slutt; i++)
    {
        if (a[i] < a[minIndex])
        {
            minIndex = i;
        }
    }
    return minIndex;
}

public static void Bytt(int[] a, int i, int j)
{
    int temp = a[i];
    a[i] = a[j];
    a[j] = temp;
}

public static int[] GenererTilfeldigPermutasjon(int lengde)
{
    Random random = new Random();
    int[] permutasjon = new int[lengde];

    for (int i = 0; i < lengde; i++)
    {
        permutasjon[i] = i + 1;
    }

    for (int i = lengde - 1; i > 0; i--)
    {
        int tilfeldigIndex = random.Next(0, i + 1);
        Bytt(permutasjon, i, tilfeldigIndex);
    }

    return permutasjon;
}
}
