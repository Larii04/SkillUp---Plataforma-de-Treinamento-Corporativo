import { Link } from "react-router-dom";

export function ForgotPasswordPage() {
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
        <Link to="/" className="auth-link">
          Voltar para o login
        </Link>
      </p>
    </div>
  );
}
