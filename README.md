# Documentação da API.
## Produtos
* Fornecer as funções de cadastro, litagem e exclusão de produto no banco de dados referente ao estoque.
### Endpoints
1. [POST] Produtos - Cadastrar um produto no banco de dados
     * Parâmetros de entrada
        1. nome - O nome do produto - Tipo: String - Parâmetro obrigatório
        2. valor_unitario - O valor de cada unidade deste produto - Tipo: ponto flutuante - Parâmetro obrigatório e deve ser diferente de 0
        3. qtde_estoque - A quantidade de unidades em estoque - Tipo: inteiro - Parâmetro obrigatório
        * O endpoint receberá esses parâmetros através do corpo (body - json) da requisição:
    * Formato resposta
      - Caso o cadastro tenha sido feito com sucesso, haverá uma resposta do tipo Ok com a menssagem: "Produto cadastrado"
      - Caso oos valores informados sejam inválidos, será retornado uma reposta do tipo Badrequest com a menssagem: "os valores informados são inválidos"
      - Caso ocorra outro tipo de erros, será retornado uma resposta do tipo BadRequest com a menssagem: "Ocorreu um erro desconhecido"
2. [GET] Produtos - Retorna todos os produtos cadastrados no banco de dados
    * Parâmetros de entrada
      - Não requer nenhum tipo de parâmetro
    * Formato de reposta
      - Será retornada uma lista com todos os produtos cadastrados e banco em forma de objetos
      - Caso não haja nenhum produto cadastrado no banco, retornará uma lista vazia
3. [GET] Produtos{Id} - Retorna o produto do banco de dados cujo ID seja igual ao informado
    * Parâmetro de entrada
      1. Id - Será necessário informar o id do objeto desejado - Tipo: inteiro - Parâmetro obrigatório
      * O endpoint receberá esse parâmetro por meio da rota (route) da requisição
    * Formato de resposta
      - Caso o produto com o ID passado exista no banco, retornará um objeto referente à esse produto
      - Caso seja possível encontrar o porduto no banco de dados, retornará uma resposta do tipo BadRequest com a menssagem: "Ocorreu um erro desconhecido"
4. [DELETE] Produto{Id} - Excluí um porduto do banco de dados
    * Parâmetro de entrada
      1. Id - Será necessário passar o Id do produto que deseja exclir do banco - Tipo: inteiro - Parâmetro obrigatório
      - O enpoint receberá esse parâmetro por meio da rota (route) da requisição
    * Formato resposta
      - Caso seja ocorra a esclusão do produto, retornará uma resposta do tipo Ok com a menssagem: "Produto excluído com sucesso" 
      - Caso não seja possível excluir o poruto, retornará uma resposta do tipo BadRequest com a menssagem: "Ocorreu um erro desconhecido"
## Compras
* Fornece a função de venda por meio de cartão de crédito com validação do cartão utilizado
### Endpoints
1. [POST] Compras - Realiza a venda de um produto e altera a quantidade deste no banco de dados
     * Parâmetros de entrada
        1. produto_id - Id do produto a ser vendido - Tipo: inteiro - Parâmetro Obrigatório
        2. qtde_comprada - Quantidade a ser vendida - tipo: inteiro - Parâmetro obrigatório
        3. cartao - Informações do cartão
          * titular - Nome do titular do cartão - Tipo: string - Parâmetro obrigatório
          * numero - Numero do cartão - Tipo: string - Parâmetro obrigatório e deve possuir uma quantidade de caractéries entre 14 e 19
          * data_expedicao - Data de validade do cartão - Tipo: string - Parâmetro obrigatório 
          * bandeira - Bandeira do cartão - Tipo: string - Parâmetro obrigatório
          * cvv - Numero cvv do cartão - Tipo: string - Parâmetro obrigatório e deve ter uma quantiade de caractéries igual a 3
        * O endpoint receberá esses parâmetros através do corpo (body - json) da requisição:
    * Formato resposta
      - Caso a venda tenha sido feita com sucesso, haverá uma resposta do tipo Ok com a menssagem: "Venda realizada com sucesso"
      - Caso oos valores informados sejam inválidos, será retornado uma reposta do tipo Badrequest com a menssagem: "os valores informados são inválidos"
      - Caso ocorra outro tipo de erros, será retornado uma resposta do tipo BadRequest com a menssagem: "Ocorreu um erro desconhecido"
 
 ## Pagamento
* Fornece a função de pagamento para lojas, validando a compra
### Endpoints
1. [POST] Pagamento - Realiza o pagamento por meio do cartão com validação do mesmo
     * Parâmetros de entrada
        1. valor - Valor da venda - Tipo: double - Parâmetro Obrigatório
        2. cartao - Informações do cartão
          * titular - Nome do titular do cartão - Tipo: string - Parâmetro obrigatório
          * numero - Numero do cartão - Tipo: string - Parâmetro obrigatório e deve possuir uma quantidade de caractéries entre 14 e 19
          * data_expedicao - Data de validade do cartão - Tipo: string - Parâmetro obrigatório 
          * bandeira - Bandeira do cartão - Tipo: string - Parâmetro obrigatório
          * cvv - Numero cvv do cartão - Tipo: string - Parâmetro obrigatório e deve ter uma quantiade de caractéries igual a 3
        * O endpoint receberá esses parâmetros através do corpo (body - json) da requisição:
    * Formato resposta
      - Caso a venda tenha sido feita com sucesso, retornará um objeto com o valor da venda e o status de APROVADO
      - Caso oos valores informados sejam inválidos ou o valor da venda seja menor ou igual a 100, será retornado um objeto com o valor da venda e o status de REPROVADO
     
