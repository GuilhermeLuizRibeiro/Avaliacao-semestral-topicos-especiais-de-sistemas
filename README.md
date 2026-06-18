# Avaliação Semestral - Tópicos Especiais de Sistemas

Este repositório contém a avaliação semestral da disciplina de Tópicos Especiais de Sistemas.

O projeto é composto por:
- **SalasReuniaoApi**: uma Web API em .NET (C#) para gestão de salas de reunião, com autenticação via JWT e persistência em SQLite.
- **index.html**: um front-end simples em React (via CDN, sem necessidade de build) que consome a API para login e operações de CRUD sobre as salas.

## Pré-requisitos

- **.NET SDK 10.0** instalado. Verifique com:
  ```bash
  dotnet --version
  ```
- Um navegador web para abrir o `index.html`.

## Passo 1 — Rodar a API

1. Abra um terminal na pasta `SalasReuniaoApi`:
   ```bash
   cd SalasReuniaoApi
   ```

2. Restaure os pacotes NuGet:
   ```bash
   dotnet restore
   ```

3. Rode a API:
   ```bash
   dotnet run
   ```

   O banco de dados SQLite (`salasreuniao.db`) já está incluído no repositório com as migrations aplicadas, então não é necessário rodar `dotnet ef database update` antes de testar.

4. A API estará disponível em:
   - `http://localhost:5256`

5. (Opcional) Para testar os endpoints diretamente, acesse o Swagger em:
   ```
   http://localhost:5256/swagger
   ```

   **Mantenha este terminal aberto** — a API precisa continuar rodando para o `index.html` funcionar.

## Passo 2 — Abrir o front-end (index.html)

Com a API rodando, abra o arquivo `index.html` (na raiz do repositório) diretamente no navegador - basta dar duplo clique nele, ou abrir via `Arquivo > Abrir` no navegador.

> O `index.html` já está configurado para se conectar à API em `http://localhost:5256`. Não é necessário nenhum servidor web para servir esse arquivo; ele funciona sendo aberto localmente (`file://`).

## Passo 3 — Login

Na tela inicial, faça login com as credenciais de teste (usuário fixo, configurado na própria API):

- **Email:** `admin@email.com`
- **Senha:** `123456`

Após o login, a tela de gestão de salas será exibida, permitindo:
- Listar salas cadastradas
- Adicionar uma nova sala (Nome, Capacidade, Possui Projetor)
- Editar uma sala existente
- Excluir uma sala

## Observações

- O token JWT gerado no login expira em 1 hora; após esse período, será necessário logar novamente.
- Caso a porta `5256` já esteja em uso na máquina, ajuste a constante `API_URL` no início do `index.html` e a configuração correspondente em `Properties/launchSettings.json`.