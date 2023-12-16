#### Português (BR)

O sexto exercício da lista: Uma aplicação que implementa um Jogo da Forca.

A aplicação deve ler um arquivo CSV que contém uma lista de palavras com categorias, escolher aleatoriamente uma categoria, e depois uma palavra dessa categoria, depois rodar uma partida de Jogo da Forca utilizando essa palavra, trocando todas as letras por _. A implementação do jogo deve permitir escolher uma letra, verificar se a letra existe na palavra, substituir os _ pela letra correspondente, contar erros caso a letra não exista, e verificar se o jogador venceu ou perdeu.

A aplicação possui dois exercícios opcionais: Criar uma categoria extra de palavras, e permitir ao jogador escolher a dificuldade, que altera a quantidade de erros permitidos.

Além disso, também criei um menu no início da aplicação, que permite escolher a dificuldade e iniciar o jogo. Ele também permite jogar o jogo diversas vezes, caso o usuário queira. E por fim, a aplicação possui uma validação de entrada para permitir que apenas letras sejam digitadas.

Os conceitos utilizados nessa aplicação incluem: Enumeration types, classe Random, leitura de arquivos usando um StreamReader e uso da classe System.Text.Encoding para retirar acentuação de palavras. 

#### English

The sixth exercise from the list: An application to implement a Hangman game.

The application has to read a CSV file that contains a list of words and categories, randomly pick a category, and then pick a word from that category. After that, it has to run a match of Hangman utilizing that word, replacing all letters with a _. The implementation has to allow the player to choose a letter, check if the letter exists in the word, replace the _ with the corresponding letter, keep track of misses if the letter doesn't exist, and check if the player has won or lost the game.

The application has two optional exercises: creating an extra word category, and allow the player to choose the difficulty, which changes the amount of mistakes allowed.

Optionally, i also created a menu at the start of the application, that allows choosing the difficulty and starting the game. The menu allows playing the game as many times as the user wants. And last, the application has an input validation to only accept letters as input.

The concepts uitilized in this application include: Enumeration Types, the Random class, reading files using a StreamReader and the use of System.Text.Encoding to remove accent marks from words.