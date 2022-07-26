namespace Sequoia.Interfaces
{
    public interface IKernelException
    {
        public int Code { get; }
        public string Type { get; }
        public string Description { get; }
        public dynamic Details { get; set; }
    }
}
