using Demo.Models;

namespace Demo.Interfaces
{
    public interface IDepartmentRepository
    {

        public List<Department> GetAll();
        public Department GetById(int id);
        public void Add(Department department);
        public void Update(int id, Department department);
        public void Delete(int id);
    }
}
