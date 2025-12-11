# 📚 Sistema de Gerenciamento da Biblioteca (SGB)

Este é um projeto de console application em C# que simula um sistema completo de gerenciamento de usuários e acervo de livros para uma biblioteca. O projeto demonstra a aplicação de conceitos de **Orientação a Objetos (POO)**, **Separação de Preocupações (Arquitetura em Camadas)** e **Boas Práticas de Desenvolvimento**.

---

## 💻 Tecnologias Utilizadas

* **Linguagem:** C#
* **.NET Framework:** (Especifique a versão que você está usando, ex: .NET 8.0, .NET 6.0)
* **Estrutura:** Console Application

## 🚀 Funcionalidades Principais

O sistema é dividido em dois grandes módulos: **Autenticação** e **Gerenciamento de Acervo**.

### 1. Módulo de Autenticação (Usuários)

* **Cadastro e Login:** Sistema robusto para registro e autenticação de usuários.
* **Controle de Acesso por Papel (`UserRole`):** Define permissões de acesso:
    * `Admin`: Acesso total ao gerenciamento de livros e usuários.
    * `Padrão`: Acesso para visualizar o acervo e realizar aluguéis.
* **Segurança:** As senhas são armazenadas utilizando **Hashing (MD5)**. *(Próximo passo planejado é a migração para BCrypt/PBKDF2)*.

### 2. Módulo de Acervo e Aluguel (Livros)

* **Registro de Livros:** Administradores podem cadastrar novos títulos no acervo.
* **Consulta de Livros:** Listagem de todos os livros disponíveis com detalhes (título, autor, status).
* **Aluguel de Livros:** Usuários Padrão podem alugar livros, atualizando o status do livro para "Alugado" ou "Emprestado".
* **Devolução de Livros:** Funcionalidade para registrar a devolução de um exemplar.

### 🔑 Credenciais de Acesso (Inicialização)

Para fins de teste, o sistema inicializa um usuário administrador padrão:

| Papel | E-mail | Senha |
| :--- | :--- | :--- |
| **Admin** | `admin@biblioteca.com` | `SenhaAdmin123` |

---

## ⚙️ Estrutura do Projeto

O projeto segue o princípio de arquitetura em camadas (Models, Controllers), facilitando a manutenção e a adição de novas funcionalidades.

| Pasta/Arquivo | Responsabilidade |
| :--- | :--- |
| `Program.cs` | Gerencia o *Main Loop* (Menu Principal) e o fluxo de navegação entre os módulos. |
| `Models/User.cs` | Define a estrutura de dados do usuário e seus papéis (`UserRole`). |
| `Models/Livro.cs` | Define a estrutura de dados do livro (Título, Autor, Status, etc.). |
| `Controllers/UserController.cs` | Lógica de negócios para Autenticação (Registro, Login, Hashing de Senha). |
| `Controllers/LivroController.cs` | Lógica de negócios para o Acervo (Cadastro, Listagem, Aluguel e Devolução). |

## 🛠️ Como Executar o Projeto

Para rodar este projeto, você precisa ter o SDK do .NET instalado em sua máquina.

1.  **Clone o repositório:**
    ```bash
    git clone [LINK DO SEU REPOSITÓRIO]
    cd nome-do-projeto
    ```

2.  **Execute a aplicação:**
    ```bash
    dotnet run
    ```
    O menu interativo será iniciado no console.

## 📝 Próximos Passos & Melhorias de Infraestrutura

As seguintes melhorias estão planejadas para a infraestrutura do projeto:

* **Persistência de Dados:** Implementar o salvamento e carregamento dos dados (Usuários e Livros) utilizando persistência em arquivo (JSON/CSV) ou um banco de dados (SQL Lite ou outro).
* **Segurança (Refatoração):** Migrar a função de hashing de MD5 para um algoritmo moderno e seguro como **BCrypt** ou **PBKDF2**.
* **Validação:** Implementar validações robustas de entrada de dados (e-mail, formato de senha, campos obrigatórios).

---

<div align="center">
  **Desenvolvido por: [Seu Nome/GitHub User]**
</div>
