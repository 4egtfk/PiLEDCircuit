using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiringPi;

namespace PiLEDCircuit
{
    class Program
    {
        //Place the LED on GPIO 5 (Physical Pin 29)
        const int redLedPin = 29;

        static void Main(string[] args)
        {
            // Tell the user that we are attempting to start the GPIO
            Console.WriteLine("Initializing GPIO Interface");

            // The WiringPiSetup method is static and returns either true or false
            // Any value less than 0 represents a failure
            if (Init.WiringPiSetupPhys() >= 0)
            //ensures that it initializes the GPIO interface and reports ready to work. We will use Physical Pin Numbers
            {
                // Tell the Pi that we will send data out the GPIO
                GPIO.pinMode(redLedPin, (int)GPIO.GPIOpinmode.Output);

                //Ensure that the LED is OFF
                //Remember the supply is 3.3V(high) therefore: High-High=0 --> LED is OFF
                GPIO.digitalWrite(redLedPin, (int)GPIO.GPIOpinvalue.High);

                // Tell the user that GPIO Initialization Completed successfully
                Console.WriteLine("GPIO Initialization Complete");

                //Tell the user to press any key to Turn ON the LED
                Console.WriteLine("Press any Key to Turn LED ON");
                // Pause and wait for user to press a key
                Console.ReadKey();
                // Turn the LED ON
                GPIO.digitalWrite(redLedPin, (int)GPIO.GPIOpinvalue.Low);
                //Tell the user taht LED should be ON
                Console.WriteLine("Led is ON");

                //Tell the user to press any key to Turn OFF the LED
                Console.WriteLine("Press any Key to Turn LED OFF and Exit");
                // Pause and wait for user to press a key
                Console.ReadKey();
                //Turn LED Off
                GPIO.digitalWrite(redLedPin, (int)GPIO.GPIOpinvalue.High);
            }
            else
            {
                //Tell the user that GPIO Interface did not initialize
                Console.WriteLine("GPIO Initialization Failed!");
            }
        }

        
    }
}
