import { Link } from "react-router-dom";

export function RegisterPage() {
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
        <Link to="/" className="auth-link">
          Entrar
        </Link>
      </p>
    </div>
  );
}
