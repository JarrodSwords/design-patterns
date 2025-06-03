namespace CreationalPatterns.FactoryMethod.Domain
{
    public class Mario
    {
        public void Attack(Enemy enemy, int damage)
        {
            enemy.ReceiveDamage(damage);
        }
    }
}
