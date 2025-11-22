import { useState } from "react";
import "./App.css";

type Screen = "login" | "register" | "forgot-password";

function App() {
  const [screen, setScreen] = useState<Screen>("login");

  return (
    <div className="app-container">
      {/* LADO ESQUERDO: LOGIN / CADASTRO / ESQUECEU SENHA */}
      <div className="auth-left">
        {screen === "login" && (
          <LoginForm
            onGoToRegister={() => setScreen("register")}
            onGoToForgotPassword={() => setScreen("forgot-password")}
          />
        )}

        {screen === "register" && (
          <RegisterForm onGoToLogin={() => setScreen("login")} />
        )}

        {screen === "forgot-password" && (
          <ForgotPasswordForm onGoToLogin={() => setScreen("login")} />
        )}
      </div>

      {/* LADO DIREITO: HERO (igual em todas as telas) */}
      <div className="auth-right">
        <h1 className="hero-title">Transforme seu potencial em resultados</h1>

        <p className="hero-subtitle">
          Acesse milhares de cursos corporativos, desenvolva novas habilidades e
          impulsione sua carreira com a SkillUp.
        </p>

        <div className="hero-metrics">
          <div className="hero-metric-item">
            <h2 className="hero-metric-value">1000+</h2>
            <p className="hero-metric-label">Cursos</p>
          </div>

          <div className="hero-metric-item">
            <h2 className="hero-metric-value">50k+</h2>
            <p className="hero-metric-label">Alunos</p>
          </div>

          <div className="hero-metric-item">
            <h2 className="hero-metric-value">98%</h2>
            <p className="hero-metric-label">Satisfação</p>
          </div>
        </div>
      </div>
    </div>
  );
}

/* ---------- LOGIN ---------- */

type LoginFormProps = {
  onGoToRegister: () => void;
  onGoToForgotPassword: () => void;
};

function LoginForm({
  onGoToRegister,
  onGoToForgotPassword,
}: LoginFormProps) {
  return (
    <div className="auth-card">
      <div className="auth-logo-wrapper">
        <div className="auth-logo">🎓</div>
      </div>

      <h2 className="auth-title">Bem-vindo ao SkillUp</h2>
      <p className="auth-subtitle">
        Entre para continuar sua jornada de aprendizado
      </p>

      <label className="auth-label">E-mail</label>
      <input
        type="email"
        placeholder="seu@email.com"
        className="auth-input"
      />

      <div className="auth-label-row">
        <label className="auth-label">Senha</label>
        <button
          className="auth-link auth-link-button"
          onClick={(e) => {
            e.preventDefault();
            onGoToForgotPassword();
          }}
        >
          Esqueceu a senha?
        </button>
      </div>

      <input
        type="password"
        placeholder="••••••••"
        className="auth-input"
      />

      <button className="auth-button">Entrar</button>

      <p className="auth-footer-text">
        Ainda não tem conta?{" "}
        <button
          className="auth-link auth-link-button"
          onClick={(e) => {
            e.preventDefault();
            onGoToRegister();
          }}
        >
          Cadastre-se
        </button>
      </p>
    </div>
  );
}

/* ---------- CADASTRO ---------- */

type RegisterFormProps = {
  onGoToLogin: () => void;
};

function RegisterForm({ onGoToLogin }: RegisterFormProps) {
  return (
    <div className="auth-card">
      <div className="auth-logo-wrapper">
        <div className="auth-logo">🎓</div>
      </div>

      <h2 className="auth-title">Crie sua conta</h2>
      <p className="auth-subtitle">
        Cadastre-se para começar sua jornada de aprendizado no SkillUp.
      </p>

      <label className="auth-label">Nome completo</label>
      <input type="text" placeholder="Seu nome" className="auth-input" />

      <label className="auth-label">E-mail</label>
      <input
        type="email"
        placeholder="seu@email.com"
        className="auth-input"
      />

      <label className="auth-label">Senha</label>
      <input
        type="password"
        placeholder="Crie uma senha"
        className="auth-input"
      />

      <label className="auth-label">Confirmar senha</label>
      <input
        type="password"
        placeholder="Repita a senha"
        className="auth-input"
      />

      <button className="auth-button">Criar conta</button>

      <p className="auth-footer-text">
        Já tem uma conta?{" "}
        <button
          className="auth-link auth-link-button"
          onClick={(e) => {
            e.preventDefault();
            onGoToLogin();
          }}
        >
          Entrar
        </button>
      </p>
    </div>
  );
}

/* ---------- ESQUECEU A SENHA ---------- */

type ForgotPasswordFormProps = {
  onGoToLogin: () => void;
};

function ForgotPasswordForm({ onGoToLogin }: ForgotPasswordFormProps) {
  return (
    <div className="auth-card">
      <div className="auth-logo-wrapper">
        <div className="auth-logo">🎓</div>
      </div>

      <h2 className="auth-title">Esqueceu sua senha?</h2>
      <p className="auth-subtitle">
        Informe seu e-mail para enviarmos um link de redefinição de senha.
      </p>

      <label className="auth-label">E-mail</label>
      <input
        type="email"
        placeholder="seu@email.com"
        className="auth-input"
      />

      <button className="auth-button">Enviar instruções</button>

      <p className="auth-footer-text">
        Lembrou da senha?{" "}
        <button
          className="auth-link auth-link-button"
          onClick={(e) => {
            e.preventDefault();
            onGoToLogin();
          }}
        >
          Voltar para o login
        </button>
      </p>
    </div>
  );
}

export default App;
