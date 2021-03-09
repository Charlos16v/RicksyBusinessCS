using System;
using RicksyBusinessCS.domain;

namespace RicksyBusinessCS
{
    public class RicksyBusiness
    {
        public static void Main(string[] args)
        {
            /**
             * Crea una tarjeta de crédito para Abradolph.
             * Como es una AndromedanExpress
             * el crédito inicial es de 3000 EZIS
             */

            var abradolph = new CreditCard("Abradolph Lincler", "4916119711304546");

            Console.WriteLine("\n" + "Tarjeta de Abradolph" + "\n" +
                              "====================");
            Console.WriteLine(abradolph);

            /**
             * Construye el componente de reserva de Ovnis.
             * Recibe el objeto tarjeta de crédito del invitado/a
             * en el método dispatch(card)
             * y realiza un cargo a la tarjeta.
             * Si hay saldo suficiente se reserva un UberOvni
             * de los que estén libres.
             * El coste del ovni es de 500 EZIs.
             */

            var ufosPark = new UfosPark();

            // Da de alta en la flota de ovnis 2 UFOS.

            string[] ufosID = {"unx", "dox"};
            foreach (var ufo in ufosID) ufosPark.add(ufo);


            // Procesamos el pago y reserva de ovni de Abradolph
            ufosPark.dispatch(abradolph);

            // Mostramos el ID del ovni asignado a Abradolph
            Console.WriteLine("\nOvni de Abradolph\n" +
                              "=================");
            Console.WriteLine(ufosPark.getUfoOf(abradolph.getNumber()));

            // Mostramos el credito de la tarjeta de Abradolph
            Console.WriteLine("Credito de Abradolph: " + abradolph.getCredit());

            // Abradolph quiere reservar otro ovni.
            // El sistema detecta que ya tiene uno
            // e ignora la petición.

            Console.WriteLine("\nAbradolph quiere otro ovni\n" +
                              "==========================");
            ufosPark.dispatch(abradolph);
            Console.WriteLine("Su credito no ha cambiado: " + abradolph.getCredit());
            Console.WriteLine("Ovni de Abradolph: " + ufosPark.getUfoOf(abradolph.getNumber()));

            // A GearHead le vacía la tarjeta el alien "Cámara Lenta"
            // mientras le daba la chapa, justo antes de pagar el ovni.
            // Intenta reservarlo y el componente de reserva de ovnis
            // no le asigna ninguno.

            Console.WriteLine("\nLLega GearHead!\n" +
                              "===============");
            var gearHead = new CreditCard("Gearhead", "8888888888888888");

            gearHead.pay(3000); // le vacían la cartera

            ufosPark.dispatch(gearHead);
            Console.WriteLine("Su credito es cero: " + gearHead.getCredit());
            Console.WriteLine("No puede reservar ovni: " + ufosPark.getUfoOf(gearHead.getNumber()));

            // Squanchy deja su ovni reservado
            // antes de irse a squanchear

            Console.WriteLine("\nLLega Squanchy!\n" + "==============");
            var squanchy = new CreditCard("Squanchy", "4444444444444444");
            ufosPark.dispatch(squanchy);
            Console.WriteLine("Su credito es: " + squanchy.getCredit());
            Console.WriteLine("Su ovni es: " + ufosPark.getUfoOf(squanchy.getNumber()));

            // Morty quiere un ovni para huir de la fiesta
            // pero ya no queda ninguno disponible

            Console.WriteLine("\nAlgun ovni para Morty?\n" + "======================");
            var morty = new CreditCard("Morty", "0000000000000000");
            ufosPark.dispatch(morty);
            Console.WriteLine("Su credito no ha cambiado: " + morty.getCredit());
            Console.WriteLine("No hay ovni Morty: " + ufosPark.getUfoOf(morty.getNumber()));

            // Metemos un ovni más en la flota de ovnis
            // y mostramos la flota por consola

            Console.WriteLine("\nFlota de ovnis\n" +
                              "==============");
            ufosPark.add("trex");
            ufosPark.printUfos();

            /**
             * Construye el dispensador de packs de bienvenida.
             * Indica el numero de unidades y el coste de cada
             * uno de ellos, que es de 50 EZIs
            */

            var packExpender = new CrystalExpender(3, 50);

            // Muestra el total de packs y su precio unidad
            Console.WriteLine("\nPacks\n" +
                              "=====");
            Console.WriteLine(packExpender);

            // Abradolph compra su pack de bienvenida
            packExpender.dispatch(abradolph);

            Console.WriteLine("\nAbradolph compra su pack\n" +
                              "========================");
            Console.WriteLine("Packs\n" + packExpender);
            Console.WriteLine("Credito de Abradolph: " + abradolph.getCredit());

            // El pobre GerHead no tiene crédito para comprar su pack
            Console.WriteLine("\nGearHead sin credito para su pack\n" +
                              "=================================");
            packExpender.dispatch(gearHead);
            Console.WriteLine("Packs\n" + packExpender);
            Console.WriteLine("Credito de GearHead: " + gearHead.getCredit());

            /**
             * Vamos a automatizar ahora ambas tareas, de modo que
             * cuando llega un invitado/a se le asiga un ovni
             * y un pack y se realiza el cargo a la tarjeta.
             *
             * Para ello, crea el componente receptivo
             * y registra (añade) los componentes UfosPark
             * y CrystalDispatcher al receptivo
             */

            var receptivo = new Receptivo();
            receptivo.registra(packExpender);
            receptivo.registra(ufosPark);

            // Implementa el metodo receptivo.dispatch()
            // para que invoque a UfosPark.dispatch()
            // y a CrystalExpender.dispatch()

            // Squanchy reserva ovni (ya tiene) y pack

            Console.WriteLine("\nLLega Squanchy!\n" +
                              "===============");
            receptivo.dispatch(squanchy);
            mostrarReserva(squanchy, packExpender, ufosPark);

            // Gearhead reserva ovni y pack.
            // No tiene crédito.

            Console.WriteLine("\nLLega GearHead!\n" +
                              "===============");
            gearHead.pay(3000); // no tiene crédito
            receptivo.dispatch(gearHead);
            mostrarReserva(gearHead, packExpender, ufosPark);

            // Birdpearson es recibido en la fiesta

            Console.WriteLine("\nLLega Birdpearson!\n" +
                              "==================");
            var birdpearson = new CreditCard("Birdpearson", "1111111111111111");
            receptivo.dispatch(birdpearson);
            mostrarReserva(birdpearson, packExpender, ufosPark);

            // Morty intenta reservar un ovni y un pack pero no quedan

            Console.WriteLine("\nMorty quiere pack y ovni pero no quedan :(\n" +
                              "==========================================");
            morty = new CreditCard("Morty", "0000000000000000");
            receptivo.dispatch(morty);
            mostrarReserva(morty, packExpender, ufosPark);


            /**
             * A por el 10!!
             * Wubba lubba dub dub!!
             *
             * Añade otra tarea al receptivo,
             * de modo que 5 invitados:
             * abradolph, squanchy, morty, gearHead, birdpearson
             * encarguen un RickMenú junto
             * al ovni y al pack de bienvenida.
             * Hay 100 RickMenús y su precio es de 10 EZIs.
             * Muestra el total de pedidos y la lista de
             * invitados/as que han hecho un pedido.
             */

            Console.WriteLine("\nTodo el mundo quiere RickMenu's!\n" + "==========================================");
            var rickMenu = new RickMenu(100, 10);
            receptivo.registra(rickMenu);

            Console.WriteLine("\nAbradolph!\n");
            receptivo.dispatch(abradolph);
            mostrarReserva(abradolph, packExpender, ufosPark, rickMenu);

            Console.WriteLine("\nSquanchy!\n");
            receptivo.dispatch(squanchy);
            mostrarReserva(squanchy, packExpender, ufosPark, rickMenu);

            Console.WriteLine("\nMorty!\n");
            receptivo.dispatch(morty);
            mostrarReserva(morty, packExpender, ufosPark, rickMenu);

            Console.WriteLine("\nGearHead!\n");
            receptivo.dispatch(gearHead);
            mostrarReserva(gearHead, packExpender, ufosPark, rickMenu);

            Console.WriteLine("\nBirdpearson!\n");
            receptivo.dispatch(birdpearson);
            mostrarReserva(birdpearson, packExpender, ufosPark, rickMenu);

            Console.WriteLine("\nTotal RickMenus!\n" + "==========================================");
            Console.WriteLine(rickMenu);
        }

        // With RickMenu
        private static void mostrarReserva(CreditCard card, CrystalExpender expender, UfosPark ufos, RickMenu rickMenu)
        {
            Console.WriteLine(card);
            Console.WriteLine("Packs: " + expender.getStock());
            Console.WriteLine("Ovni: " + ufos.getUfoOf(card.getNumber()));
            Console.WriteLine("Menus: " + rickMenu.getStock());
        }

        private static void mostrarReserva(CreditCard card, CrystalExpender expender, UfosPark ufos)
        {
            Console.WriteLine(card);
            Console.WriteLine("Packs: " + expender.getStock());
            Console.WriteLine("Ovni: " + ufos.getUfoOf(card.getNumber()));
        }
    }
}