CRUD de Usuários com Stored Procedures

Este é um projeto de um sistema CRUD para gerenciamento de usuários, desenvolvido em .NET 8 e ASP.NET Core MVC. Toda a comunicação com o banco de dados é feita exclusivamente por meio de stored procedures, garantindo mais controle e eficiência nas operações.

📋 Descrição do Projeto

O projeto demonstra um CRUD completo, com as funcionalidades de criação, leitura, atualização e exclusão de usuários, integradas com stored procedures. Esta abordagem traz vantagens como:
Maior controle sobre as transações no banco de dados.
Melhor desempenho em operações complexas.
Separação das regras de negócio na camada de banco de dados.

🚀 Tecnologias Utilizadas

.NET 8 - Plataforma principal de desenvolvimento.
ASP.NET Core MVC - Framework para construção do frontend.
SQL Server - Banco de dados utilizado.
Stored Procedures - Procedimentos armazenados para operações de CRUD.

📦 Estrutura do Projeto

O projeto está organizado nas seguintes camadas principais:

Controllers: Responsáveis por lidar com as requisições HTTP e enviar respostas apropriadas.
Models: Define as entidades de domínio, como o modelo de usuário.
Views: Camada de apresentação que exibe as interfaces para o usuário.
Data Access Layer: Realiza a interação com o banco de dados por meio de stored procedures.

⚙️ Funcionalidades

Adicionar Usuário: Insere um novo registro de usuário.
Listar Usuários: Exibe todos os usuários cadastrados no banco de dados.
Editar Usuário: Permite a atualização das informações de um usuário existente.
Excluir Usuário: Remove um usuário do banco de dados.

📂 Estrutura das Stored Procedures

As stored procedures estão organizadas para realizar cada uma das operações CRUD, com foco em segurança e performance. Cada procedimento foi criado para otimizar o acesso e a manipulação dos dados de usuário.

🛠️ Como Executar o Projeto

Clone o repositório:
bash
Copiar código
git clone https://github.com/brunofsilva1989/CrudUsuariosStoredProcedure.git
Configure a conexão com o SQL Server no arquivo appsettings.json.
Crie as stored procedures necessárias no banco de dados, conforme descrito na documentação do projeto.
Execute o projeto no Visual Studio ou .NET CLI.

🤝 Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para fazer um fork do repositório e enviar um pull request com melhorias ou correções.
