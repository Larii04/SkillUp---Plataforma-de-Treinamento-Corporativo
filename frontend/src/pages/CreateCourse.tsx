import { useNavigate } from "react-router-dom";

export function CreateCoursePage() {
  const navigate = useNavigate();

  function handleSubmit(event: React.FormEvent) {
    event.preventDefault();
    // aqui depois você chama o backend para salvar o curso
    // por enquanto, só volta pro Dashboard:
    navigate("/dashboard");
  }

  function handleCancel() {
    navigate("/dashboard");
  }

  return (
    <div className="dashboard-page">
      {/* Cabeçalho */}
      <header className="dashboard-header">
        <div>
          <h1 className="dashboard-title">Criar curso</h1>
          <p className="dashboard-subtitle">
            Preencha as informações abaixo para cadastrar um novo curso na plataforma.
          </p>
        </div>

        <div className="dashboard-header-actions">
          <button
            type="button"
            className="dashboard-button-secondary"
            onClick={handleCancel}
          >
            Cancelar
          </button>

          <button
            type="submit"
            form="create-course-form"
            className="dashboard-button-primary"
          >
            Salvar curso
          </button>
        </div>
      </header>

      {/* Formulário */}
      <form id="create-course-form" className="course-form" onSubmit={handleSubmit}>
        <div className="course-form-grid">
          {/* Nome */}
          <div className="form-group">
            <label className="form-label">Nome do curso</label>
            <input
              type="text"
              className="form-input"
              placeholder="Ex.: Onboarding de novos colaboradores"
            />
          </div>

          {/* Categoria */}
          <div className="form-group">
            <label className="form-label">Categoria</label>
            <select className="form-input">
              <option value="">Selecione uma categoria</option>
              <option value="onboarding">Onboarding</option>
              <option value="compliance">Compliance</option>
              <option value="softskills">Soft skills</option>
              <option value="gestao">Gestão</option>
              <option value="seguranca">Segurança</option>
            </select>
          </div>

          {/* Nível */}
          <div className="form-group">
            <label className="form-label">Nível</label>
            <select className="form-input">
              <option value="">Selecione o nível</option>
              <option value="iniciante">Iniciante</option>
              <option value="intermediario">Intermediário</option>
              <option value="avancado">Avançado</option>
            </select>
          </div>

          {/* Thumbnail */}
          <div className="form-group">
            <label className="form-label">Thumbnail / Capa do curso</label>
            <input type="file" className="form-input" />
            <span className="form-help">
              Formatos aceitos: JPG, PNG. Tamanho máximo: 5MB.
            </span>
          </div>
        </div>

        {/* Descrição */}
        <div className="form-group">
          <label className="form-label">Descrição do curso</label>
          <textarea
            className="form-input form-textarea"
            placeholder="Explique brevemente o objetivo do curso e o que o colaborador irá aprender."
          />
        </div>

        {/* Curso obrigatório */}
        <div className="form-group form-group-inline">
          <label className="form-checkbox-row">
            <input type="checkbox" />
            <span>Curso obrigatório para todos os colaboradores</span>
          </label>
        </div>

        <div className="form-footer-note">
          Objetivo: permitir que o administrador cadastre novos cursos de forma rápida, 
          mantendo uma visão clara das informações principais.
        </div>
      </form>
    </div>
  );
}
