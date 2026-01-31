# ClearEmailBox 📧🧹

Aplicação console desenvolvida em **C# (.NET)** com integração à **Gmail API**, utilizando **OAuth 2.0**, com o objetivo de automatizar ações na caixa de entrada do Gmail.

O projeto permite autenticar o usuário de forma segura e realizar operações como leitura de mensagens e movimentação de e-mails para a lixeira.

---

## 🚀 Funcionalidades

- Autenticação segura via OAuth 2.0
- Integração com a Gmail API
- Listagem de e-mails da conta autenticada
- Marcação de e-mails como lidos
- Movimentação de e-mails para a lixeira (TRASH)
- Token persistente para evitar autenticações repetidas

---

## 🛠️ Tecnologias Utilizadas

- C# (.NET)
- Google Gmail API
- OAuth 2.0
- Google.Apis.Gmail.v1
- Console Application

---

## 📂 Estrutura do Projeto

ClearEmailBox/
├── Program.cs
├── ClearEmailBox.csproj
├── credentials/
│ └── client_secret.json (ignorado no Git)
└── token.json (gerado automaticamente)


> ⚠️ Arquivos sensíveis como credenciais OAuth não são versionados no repositório.

---

## 🔐 Autenticação

O projeto utiliza OAuth 2.0 para autenticação segura com a conta Google do usuário.  
Na primeira execução, o navegador será aberto para consentimento. Após isso, um token local é gerado e reutilizado nas próximas execuções.

---

## ▶️ Como Executar

1. Clone o repositório
2. Configure as credenciais OAuth no Google Cloud Console
3. Adicione o arquivo `client_secret.json` na pasta `credentials/`
4. Execute o comando:

```bash
dotnet run

🎯 Objetivo do Projeto

Este projeto foi desenvolvido com foco em aprendizado prático, explorando:

Integração com APIs externas

Fluxos reais de autenticação

Automação de tarefas

Boas práticas de segurança

📌 Observações

Projeto em constante evolução, utilizado como estudo e base para automações futuras.
