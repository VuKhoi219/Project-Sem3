namespace Project_Sem3.Helper;

public class CalculateInsurance
{
    // ví dụ  : 
    // decimal insuranceAmount = 500000000; // 500 triệu VND
    // decimal basicFee = 0.005m; // 0.5%
    // decimal ageCoefficient = 1.2m; // 40 tuổi
    // decimal healthCoefficient = 1.3m; // Tiểu đường
    // decimal insuranceCost = LifeInsurance(insuranceAmount, basicFee, ageCoefficient, healthCoefficient);
    public decimal LifeInsurance(decimal insuranceAmount, decimal basicFee, decimal ageCoefficient,
        decimal healthCoefficient)
    {
        if (insuranceAmount <= 0 || basicFee <= 0 || ageCoefficient <= 0 || healthCoefficient <= 0)
        {
            throw new ArgumentException("Các giá trị đầu vào phải lớn hơn 0.");
        }
        return insuranceAmount * basicFee * ageCoefficient * healthCoefficient;
    }
    
    // decimal healthInsuranceCost = HealthInsurance(100000000, 0.002m, 1.1m, 1.2m);
    // Console.WriteLine($"Phí bảo hiểm y tế: {healthInsuranceCost:N0} VND");
    public decimal HealthInsurance(decimal insuranceAmount, decimal baseRate, decimal ageCoefficient, decimal healthCoefficient)
    {
        if (insuranceAmount <= 0 || baseRate <= 0 || ageCoefficient <= 0 || healthCoefficient <= 0)
        {
            throw new ArgumentException("Các giá trị đầu vào phải lớn hơn 0.");
        }

        return insuranceAmount * baseRate * ageCoefficient * healthCoefficient;
    }
    
    // decimal autoInsuranceCost = AutoInsurance(500000000, 0.01m, 1.05m, 1.2m);
    // Console.WriteLine($"Phí bảo hiểm xe cơ giới: {autoInsuranceCost:N0} VND");
    public decimal AutoInsurance(decimal carValue, decimal baseRate , decimal carTypeCoefficient, decimal accidentCoefficient)
    {
        if (carValue <= 0 || baseRate <= 0 || carTypeCoefficient <= 0 || accidentCoefficient <= 0)
        {
            throw new ArgumentException("Các giá trị đầu vào phải lớn hơn 0.");
        }

        return carValue * baseRate * carTypeCoefficient * accidentCoefficient;
    }
    
    // decimal homeInsuranceCost = HomeInsurance(2000000000, 0.005m, 1.2m, 1.5m);
    // Console.WriteLine($"Phí bảo hiểm nhà ở: {homeInsuranceCost:N0} VND");
    public decimal HomeInsurance(decimal homeValue, decimal baseRate, decimal locationCoefficient, decimal disasterRiskCoefficient)
    {
        if (homeValue <= 0 || baseRate <= 0 || locationCoefficient <= 0 || disasterRiskCoefficient <= 0)
        {
            throw new ArgumentException("Các giá trị đầu vào phải lớn hơn 0.");
        }

        return homeValue * baseRate * locationCoefficient * disasterRiskCoefficient;
    }
}