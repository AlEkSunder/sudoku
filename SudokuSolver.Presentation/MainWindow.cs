using SudokuSolver.ViewModel.Concrete;

namespace SudokuSolver.Presentation
{
    public partial class MainWindow : Form
    {
        private SudokuSolverViewModel viewModel;

        public MainWindow(SudokuSolverViewModel sudokuSolverViewModel)
        {
            this.InitializeComponent();
            this.viewModel = sudokuSolverViewModel;
        }

        private void OnMainWindow_Load(object sender, EventArgs e)
        {
            this.fieldDataGridView.DataSource = viewModel.Rows;
        }

        private void OnNextStep_Click(object sender, EventArgs e)
        {
            this.viewModel.NextStep.Execute(null);

            if (this.viewModel.IsFinished)
            {
                this.nextStepBtn.Enabled = false;
                this.finishLabel.Visible = true;
            }
        }
    }
}