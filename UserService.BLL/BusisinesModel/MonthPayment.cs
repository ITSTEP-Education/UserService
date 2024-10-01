
namespace UserService.BLL.BusisinesModel
{
    public class MonthPayment
    {
        private int mounthQty;
        private float sumPay;

        public MonthPayment(float sumPay, int mounthQty)
        {
            this.mounthQty = mounthQty;
            this.sumPay = sumPay;
        }

        public int getMountрPay() => (int)(sumPay / mounthQty);
    }
}
