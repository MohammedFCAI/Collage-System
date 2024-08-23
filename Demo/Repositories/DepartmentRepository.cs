using Demo.Contexts;
using Demo.Models;

namespace Demo.Repositories
{
    public class DepartmentRepository
    {
        // IOC Inversion of Control
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return _context.Departments.Find(id);
        }

        public void Add(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void Update(int id, Department department)
        {
            // get old object
            // set new values
            var oldDepartment = GetById(id);

            oldDepartment.Name = department.Name;
            oldDepartment.ManagerName = department.ManagerName;

            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            //old
            var department = GetById(id);

            _context.Departments.Remove(department);


            _context.SaveChanges();
        }


        //public int GetMaxArea(int[] heights)
        //{
        //    int maxArea = 0, left = 0, right = heights.Length - 1;


        //    while (left < right)
        //    {

        //        // 1. Get Width: 
        //        var width = right - left;

        //        var minHeight = Math.Min(heights[left], heights[right]);

        //        var area = width * minHeight;

        //        maxArea = Math.Max(maxArea, area);


        //        if (heights[left] < heights[right])
        //            left++;
        //        else
        //            right--;
        //    }
        //    return maxArea;
        //}
    }
}
