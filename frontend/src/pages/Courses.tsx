import { useNavigate } from "react-router-dom";

type CourseStatus = "rascunho" | "publicado";

type Course = {
  id: number;
  nome: string;
  categoria: string;
  modulos: number;
  status: CourseStatus;
  thumbnail?: string;
};

const cursosMock: Course[] = [
  {
    id: 1,
    nome: "Onboarding de novos colaboradores",
    categoria: "Onboarding",
    modulos: 5,
    status: "publicado",
  },
  {
    id: 2,
    nome: "Segurança da informação",
    categoria: "Compliance",
    modulos: 4,
    status: "publicado",
  },
  {
    id: 3,
    nome: "Comunicação não violenta",
    categoria: "Soft skills",
    modulos: 3,
    status: "rascunho",
  },
];

export function CoursesPage() {
  const navigate = useNavigate();

  function getStatusLabel(status: CourseStatus) {
    if (status === "publicado") return "Publicado";
    return "Rascunho";
  }

  return (
    <div className="dashboard-page">
      {/* Cabeçalho */}
      <header className="dashboard-header">
        <div>
          <h1 className="dashboard-title">Gestão de cursos</h1>
          <p className="dashboard-subtitle">
            Visualize, gerencie e publique os cursos da plataforma.
          </p>
        </div>

        <div className="dashboard-header-actions">
          <button
            className="dashboard-button-secondary"
            onClick={() => navigate("/dashboard")}
          >
            Voltar para o Dashboard
          </button>

          <button
            className="dashboard-button-primary"
            onClick={() => navigate("/dashboard/courses/new")}
          >
            + Criar novo curso
          </button>
        </div>
      </header>

      {/* Lista de cursos */}
      <section className="courses-section">
        <div className="courses-header-row">
          <span className="courses-header-title">Cursos cadastrados</span>
          <span className="courses-header-count">
            {cursosMock.length} curso(s)
          </span>
        </div>

        <div className="courses-table">
          <div className="courses-table-head">
            <span>Curso</span>
            <span>Categoria</span>
            <span>Nº de módulos</span>
            <span>Status</span>
            <span>Ações</span>
          </div>

          <div className="courses-table-body">
            {cursosMock.map((curso) => (
              <div key={curso.id} className="courses-table-row">
                {/* Thumbnail + nome */}
                <div className="courses-col-main">
                  <div className="courses-thumb" />
                  <div>
                    <p className="courses-name">{curso.nome}</p>
                  </div>
                </div>

                {/* Categoria */}
                <span className="courses-col-text">{curso.categoria}</span>

                {/* Módulos */}
                <span className="courses-col-text">{curso.modulos}</span>

                {/* Status */}
                <span
                  className={`courses-status courses-status-${curso.status}`}
                >
                  {getStatusLabel(curso.status)}
                </span>

                {/* Ações */}
                <div className="courses-actions">
                  <button className="courses-action-link">Editar</button>
                  <button className="courses-action-link">
                    Ver progresso
                  </button>
                  <button className="courses-action-link">
                    {curso.status === "publicado"
                      ? "Despublicar"
                      : "Publicar"}
                  </button>
                </div>
              </div>
            ))}
          </div>
        </div>
      </section>
    </div>
  );
}
