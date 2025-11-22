# 📘 SkillUp – Plataforma de Treinamento Corporativo  
Sistema completo de cursos internos utilizando **.NET 8**, **PostgreSQL**, **CQRS**, **JWT**, **QuestPDF**, **MailKit** e arquitetura limpa.

---

## 🚀 Visão Geral

O **SkillUp** é uma plataforma para treinamento corporativo, permitindo que empresas criem cursos internos, disponibilizem módulos, lições e questionários, e acompanhem o progresso dos colaboradores.

---

## 🧱 Arquitetura do Projeto

A solução segue **Clean Architecture + Domain-Driven Design + CQRS**:

SkillUp.sln
└── src/
├── SkillUp.Domain → Entidades, enums, regras de domínio
├── SkillUp.Application → Commands, queries, services, DTOs
├── SkillUp.Infra → EF Core, repositórios, serviços
└── SkillUp.Api → Controllers, autenticação, Swagger

yaml
Copiar código

---

## 🔐 Autenticação

Autenticação baseada em **JWT**.

### Endpoint de Login

POST /auth/login

css
Copiar código

Body:

```json
{
  "email": "admin@skillup.com",
  "senha": "admin123"
}
Retorno:

json
Copiar código
{
  "token": "jwt...",
  "usuario": {
    "id": "...",
    "nome": "Administrador",
    "email": "admin@skillup.com",
    "papel": "Admin"
  }
}
Use o token no front:

makefile
Copiar código
Authorization: Bearer <token>
👤 Usuários pré-criados (Seed)
Tipo	Email	Senha
Admin	admin@skillup.com	admin123
Colaborador	colaborador@skillup.com	colab123

🗄️ Banco de Dados
Conexão (PostgreSQL)
Configure em:

bash
Copiar código
src/SkillUp.Api/appsettings.json
Exemplo:

json
Copiar código
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=skillup;Username=postgres;Password=postgres;"
}
🛠️ Como rodar o projeto
1. Restaurar dependências
bash
Copiar código
dotnet restore
2. Criar o banco + aplicar migrations
bash
Copiar código
dotnet ef database update --project src/SkillUp.Infra --startup-project src/SkillUp.Api
3. Executar a API
bash
Copiar código
dotnet run --project src/SkillUp.Api
API disponível em:

arduino
Copiar código
https://localhost:7143
http://localhost:5143
Swagger:

bash
Copiar código
/swagger/index.html
📚 Funcionalidades
✔️ Cursos
Criar, editar, excluir (Admin)

Listar, detalhar (Autenticado)

Upload de thumbnail

Várias categorias e níveis

✔️ Módulos e Lições
Conteúdo em vídeo, PDF ou texto

Ordem configurável

Conclusão de lição

Progresso automático

✔️ Questionários
Múltipla escolha

Correção automática

Nota, aprovação e histórico

Integração com conclusão do curso

✔️ Certificados
Geração automática ao concluir curso

Render em PDF usando QuestPDF

Template com imagem base

Envio automático por email via MailKit

Código de verificação único

Certificados ficam em:

swift
Copiar código
backend/CertificadosGerados/
🔧 Configurações Importantes
Template do Certificado
bash
Copiar código
backend/Templates/certificado_base.png
Se não existir, crie a pasta e adicione sua imagem.

📨 Configuração de Email
No appsettings.json:

json
Copiar código
"Email": {
  "Host": "smtp.meuservidor.com",
  "Porta": "587",
  "Usuario": "meuemail",
  "Senha": "minhasenha",
  "RemetenteNome": "SkillUp",
  "RemetenteEmail": "no-reply@skillup.com"
}
📦 Principais Endpoints
► Cursos
bash
Copiar código
GET    /api/cursos
GET    /api/cursos/{id}
POST   /api/cursos       (Admin)
PUT    /api/cursos/{id}  (Admin)
DELETE /api/cursos/{id}  (Admin)
► Lições
bash
Copiar código
POST /api/licoes/{licaoId}/concluir
► Questionários
swift
Copiar código
GET  /api/questionarios/curso/{cursoId}
POST /api/questionarios/curso/{cursoId}/responder
► Usuários
pgsql
Copiar código
GET  /api/usuarios (Admin)
POST /api/usuarios (Admin)
🤝 Integração com o Front-end (Angular / React / Vue)
Para proteger rotas:

ts
Copiar código
const token = localStorage.getItem("token");

fetch("http://localhost:5143/api/cursos", {
  headers: {
    Authorization: `Bearer ${token}`
  }
});
🧪 Testes no Swagger
Acesse:

bash
Copiar código
https://localhost:7143/swagger
Faça login → copie o token → clique em "Authorize".

📄 Licença
MIT License

