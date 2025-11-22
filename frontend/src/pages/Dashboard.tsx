import { useNavigate } from "react-router-dom";

export function DashboardPage() {
  const navigate = useNavigate();

  const totalCursos = 24;
  const alunosInscritos = 320;
  const taxaConclusao = 82;
  const cursosEngajamento = [
    { nome: "Onboarding de novos colaboradores", engajamento: "92%" },
    { nome: "Segurança da informação", engajamento: "88%" },
    { nome: "Liderança para gestores", engajamento: "85%" },
  ];

  return (
    <div className="dashboard-page">
      {/* topo */}
      <header className="dashboard-header">
        <div>
          <h1 className="dashboard-title">Dashboard ADM</h1>
          <p className="dashboard-subtitle">
            Visão macro dos cursos e engajamento dos colaboradores.
          </p>
        </div>

        <div className="dashboard-header-actions">
          <button
            className="dashboard-button-primary"
            onClick={() => navigate("/dashboard/courses")}
          >
            Ver cursos
          </button>

          <button
            className="dashboard-button-secondary"
            onClick={() => navigate("/")}
            >
            Sair
            </button>
        </div>
      </header>

      {/* cards de indicadores principais */}
      <section className="dashboard-kpis">
        <div className="dashboard-kpi-card">
          <span className="dashboard-kpi-label">Nº total de cursos</span>
          <strong className="dashboard-kpi-value">{totalCursos}</strong>
        </div>

        <div className="dashboard-kpi-card">
          <span className="dashboard-kpi-label">Alunos inscritos</span>
          <strong className="dashboard-kpi-value">{alunosInscritos}</strong>
        </div>

        <div className="dashboard-kpi-card">
          <span className="dashboard-kpi-label">Taxa média de conclusão</span>
          <strong className="dashboard-kpi-value">{taxaConclusao}%</strong>
        </div>
      </section>

      {/* cursos com maior engajamento */}
      <section className="dashboard-section">
        <div className="dashboard-section-header">
          <h2 className="dashboard-section-title">
            Cursos com maior engajamento
          </h2>
          <span className="dashboard-section-subtitle">
            Ordenado pelos cursos com maior taxa de conclusão e participação.
          </span>
        </div>

        <div className="dashboard-engagement-list">
          {cursosEngajamento.map((curso) => (
            <div key={curso.nome} className="dashboard-engagement-item">
              <div>
                <p className="dashboard-engagement-name">{curso.nome}</p>
                <p className="dashboard-engagement-label">
                  Engajamento dos alunos
                </p>
              </div>
              <span className="dashboard-engagement-badge">
                {curso.engajamento}
              </span>
            </div>
          ))}
        </div>
      </section>
    </div>
  );
}
