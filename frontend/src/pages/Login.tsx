import { Link, useNavigate } from "react-router-dom";

export function LoginPage() {
  const navigate = useNavigate();

  function handleLogin() {
    // depois você coloca a chamada pro backend aqui
    navigate("/dashboard");
  }

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
        <Link to="/forgot-password" className="auth-link">
          Esqueceu a senha?
        </Link>
      </div>

      <input
        type="password"
        placeholder="••••••••"
        className="auth-input"
      />

      <button className="auth-button" onClick={handleLogin}>
        Entrar
      </button>

      <p className="auth-footer-text">
        Ainda não tem conta?{" "}
        <Link to="/register" className="auth-link">
          Cadastre-se
        </Link>
      </p>
    </div>
  );
}
