using System;
using System.IO;
using System.Linq;

namespace CeasarsCypher
{
	class MainClass 													// this class, is used to contain the method, Main, which contains the Menu, as to which the encryptio and decryption will take place for the end user.
	{
		public static void Main (string[] args)
		{
			string file = File.ReadAllText(@"caesarShiftEncodedText.txt"); // the text document is read, so that all the text within it, is assigned within the string, called 'file'.
			Console.WriteLine("Enter E to Encrypt and D to Decrypt");
			string menu = Convert.ToString(Console.ReadLine()).ToUpper();
			string input = "", output = ""; 							// used to define the input date, dependant on the user, through Console.ReadLines().
			int shift = 0; 												// used to relate to the if statement and to actually shift the number of characters, depending on the user input.
			
			cryption function = new cryption (); 						// Creates an instance to get to the other classes, in this case, cryption.
			
			using (StreamWriter sw = File.CreateText(@"Decryption_Outputs.txt")) // used to  create an outputting document.
            {
                sw.WriteLine("Decryption Outputs! \n");	
            }
			
			switch (menu) 												// switch used for a menu option, so that the end user has an option to encrypt or decrypt.
			
			{
				case "E": 												// used as a possible selection for the end user. case E, is used as an option for the encryption method.
				
				Console.WriteLine("Encrytion \n type a string to encrypt! \n (the encryption has to be done in capitals!)");
				input = Console.ReadLine();
				input = input.ToUpper(); 								// used to convert the input into capital letters.
				
				
				Console.WriteLine("How many characters would you like to shift by?");
				shift = Convert.ToInt32(Console.ReadLine()); 			// used to convert the shift value into an integer data type.
				
				output = function.calculation(shift, input); 			// this is used to fetch the output from the calculation method.
				
				Console.WriteLine("Your Encrypted Code is...\n{0}", output);
				
        		Console.Read();
				break; 													// used to seperate the different available values within the switch.
				
				case "D": 												// used for the decryption method. 
				Console.WriteLine("Decryption"); 						// decryption
				
				input = file; 											// used to access the file.
				for(shift = 0; shift < 26; shift ++) 					// the for loop is needed to shift a number of 26 times.
				 {
					output = function.calculation(shift, input); 		// outputs the answer from the calculation method.
					Console.WriteLine('\n' + output); 					// Writes the output value within the console.
					using (StreamWriter sw = File.AppendText(@"Decryption_Outputs.txt"))  // used to get the shift and output values from the decryption calculation.
            		{
                		sw.WriteLine("shift = {0}, 			{1}", shift, output);
            		}
							// data fed into a function, within brackets are called an 'argument'.
				 }
				 Console.WriteLine("\n The code has now been decrypted and saved! \n\n Please look into your cipher directory to find the file!");
				 Console.ReadLine();
				break;
				
				case "Q": 	// used to quit the application.
				
				Environment.Exit(0);
				break;
				default: 	// this is implemented, with the console.WriteLine, so that if the an incorrect value is used, the user will have to try again.
				Console.WriteLine("Error! Please use the correct character!");
				break;
			}
		}
	}
	class cryption 			// a class, which contains methods, such as calculation.
	{		

		public string calculation(int shift, string message)
		{ 					// calculation method, which supplies answers for both the decryption and encryption coding areas.
		
				char[] Alphabet = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
				
							// an array named Alphabet. this contains all the values to actually decrypt the file.
							
			char character = ' '; 			// the variable character is given a value of a 'blank space'. blank spaces are used to prevent errors occuring within the code.

			string answer = " ";			// supplies the end user with the answer for the decryption.

			int position = 0;				// will provide me with a position number, depending on where the shifted character is.
			
				foreach(char x in message) // it will repeat the loop, the number of times it is declared within the 'for' statement, then will be outputted in message.
				{	
					character = x; 		   // the variable 'x', within character will be assigned, within the message, then will assign itself to the variable character.
	
					if(Alphabet.Contains(character)) // if the alphabet array, contains a character, do the following instructions. it is used to filter through the characters ONLY.
					{
						position = Array.IndexOf(Alphabet, character); 

													// Finds the character inside the alphabet and wil return the position number of this character, it is then assigned depending on the position.

													// the position of the array, allows me to shift the letters, depending on how many letters i want to shift by.

						position = position + shift;

													// now add a function or 'if' statement. So if the character value hits the alphabetical value of 'z', it can refer back to the start of the alphabet.

						if (position > 25)
						{
							position = position - 26;

						}
						else if(position < 0)
						{
							position += 26;
						}

						answer += Alphabet[position];

							// the entirety of the variable alphabet is selected, thereafter, depending on the value of the position, a very particular value is found.	
					}
				}
			return answer; // used to return the calculating answer, within the console.
		}
	}
}