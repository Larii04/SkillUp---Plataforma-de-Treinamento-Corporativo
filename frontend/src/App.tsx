import { Routes, Route, Outlet } from "react-router-dom";
import "./App.css";
import { LoginPage } from "./pages/Login";
import { RegisterPage } from "./pages/Register";
import { ForgotPasswordPage } from "./pages/ForgotPassword";
import { DashboardPage } from "./pages/Dashboard";
import { CoursesPage } from "./pages/Courses";
import { CreateCoursePage } from "./pages/CreateCourse";


function App() {
  return (
    <Routes>
      {/* Layout de autenticação */}
      <Route element={<AuthLayout />}>
        <Route path="/" element={<LoginPage />} />
        <Route path="/register" element={<RegisterPage />} />
        <Route path="/forgot-password" element={<ForgotPasswordPage />} />
      </Route>

      {/* Dashboard tela cheia */}
      <Route path="/dashboard" element={<DashboardPage />} />
      <Route path="/dashboard/courses" element={<CoursesPage />} />
      <Route path="/dashboard/courses/new" element={<CreateCoursePage />} />

    </Routes>

  );
}

/** Layout padrão das telas de login/cadastro/esqueceu */
function AuthLayout() {
  return (
    <div className="app-container">
      <div className="auth-left">
        <Outlet />
      </div>

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

export default App;
