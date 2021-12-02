import string

def caesar2(plaintext, shift): 

    shift %= 26 # Values greater than 26 will wrap around

    alphabet_lower = string.ascii_lowercase
    alphabet_upper = string.ascii_uppercase

    shifted_alphabet_lower = alphabet_lower[shift:] + alphabet_lower[:shift]
    shifted_alphabet_upper = alphabet_upper[shift:] + alphabet_upper[:shift]

    alphabet = alphabet_lower + alphabet_upper 
    shifted_alphabet = shifted_alphabet_lower + shifted_alphabet_upper

    table = str.maketrans(alphabet, shifted_alphabet) 

    return plaintext.translate(table)
