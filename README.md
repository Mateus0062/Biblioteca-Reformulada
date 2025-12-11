# Biblioteca

# 📚 Sistema de Gerenciamento Básico de Usuários (Biblioteca)

Este é um projeto de console application em C# desenvolvido como um sistema de registro e login de usuários. O objetivo principal é demonstrar conceitos fundamentais de desenvolvimento, como **Orientação a Objetos (POO)**, **Separação de Preocupações (MVC/Camadas)** e **Boas Práticas de Segurança** (Hashing de Senhas).

---

## 💻 Tecnologias Utilizadas

* **Linguagem:** C#
* **.NET Framework:** .NET 10.0
* **Estrutura:** Console Application

## 🚀 Funcionalidades

O sistema oferece as seguintes funcionalidades básicas de autenticação:

1.  **Cadastro de Usuário:** Registra novos usuários, garantindo que o e-mail não seja duplicado.
2.  **Login de Usuário:** Autentica usuários com e-mail e senha.
3.  **Sistema de Papéis (`UserRole`):** Distingue entre usuários `Padrão` e `Admin` no momento do login.
4.  **Hashing de Senha:** As senhas são armazenadas de forma segura (usando **MD5** - *Nota: Em projetos reais, é recomendado usar BCrypt ou PBKDF2*).

### 🔑 Credenciais de Acesso (Inicialização)

Para fins de teste, o sistema inicializa um usuário administrador padrão:

| Papel | E-mail | Senha |
| :--- | :--- | :--- |
| **Admin** | `admin@biblioteca.com` | `SenhaAdmin123` |

---

## ⚙️ Estrutura do Projeto

O projeto é organizado em camadas para separar a lógica de negócios da interface do usuário.

| Pasta/Arquivo | Responsabilidade |
| :--- | :--- |
| `Program.cs` | Contém o *Main Loop* (Menu Principal) e gerencia o fluxo da aplicação. |
| `Models/User.cs` | Define a estrutura de dados (classe `User` e `UserRole`). |
| `Controllers/UserController.cs` | Contém a **lógica de negócios** para Registro e Login, incluindo o hashing da senha e a verificação de papéis. |

## 📝 Próximos Passos & Melhorias Futuras

Este projeto é uma base. As seguintes melhorias são planejadas:

* **Segurança:** Atualizar a função de hashing de MD5 para **BCrypt** ou **PBKDF2** para maior segurança.
* **Validação:** Adicionar validação de e-mail e força de senha no momento do cadastro.
* **Recursos da Biblioteca:** Implementar a lógica de aluguel de livros, listagem de acervo, etc.

---

<div align="center">
  Feito com ❤️ em C#
</div>
