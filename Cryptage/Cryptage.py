import string
import sys

def caesar2(plaintext): 
    
    shift = 3;
    shift %= 26 # Values greater than 26 will wrap around

    alphabet_lower = string.ascii_lowercase
    alphabet_upper = string.ascii_uppercase

    shifted_alphabet_lower = alphabet_lower[shift:] + alphabet_lower[:shift]
    shifted_alphabet_upper = alphabet_upper[shift:] + alphabet_upper[:shift]

    alphabet = alphabet_lower + alphabet_upper 
    shifted_alphabet = shifted_alphabet_lower + shifted_alphabet_upper

    table = str.maketrans(alphabet, shifted_alphabet) 

    print(plaintext.translate(table));
    return plaintext.translate(table)

nbArgument = len(sys.argv) - 1;

i = 1;
textToEncrypt ="";

while(i <= nbArgument):
    textToEncrypt += sys.argv[i] + " ";
    i+=1;

caesar2(textToEncrypt);
