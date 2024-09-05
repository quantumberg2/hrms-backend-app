using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IPosition
    {
        public List<Position> GetPositions();
        //public Position GetPositionById(int id);
        public Task<string> InsertPositions(Position position);
        public Task<Position> updateposition(int id, string? name, int? requestedcompanyId);
        public Task<bool> deletePosition(int id);
        public bool SoftDelete(int id, short isActive);
    }
}
