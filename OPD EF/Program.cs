namespace OPD_EF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.GetUsers();
                var comments = db.GetComments();
                Console.WriteLine(" Получаем Списки объектов:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name}");
                }
                foreach (Comment u in comments)
                {
                    Console.WriteLine($"{u.User.Name} пишет {u.Text}");
                }

                var user = db.GetUser(1);
                var comm = db.GetComment(1);
                Console.WriteLine("\n/////////////////////////////////////////\n");
                Console.WriteLine(user.Name + " - Индивид коллекции");
                Console.WriteLine(comm.Text + " - Индивид коллекции");
                var newU = new User(){ Name = "Миша",Password= "dsasa", Email="dsds@ds"};
                db.SetUser(newU);
                var newC = new Comment() { Text = "dsddsds", UserId = 4 };
                db.SetComment(newC);

                users = db.GetUsers();
                comments = db.GetComments();
                Console.WriteLine("\n/////////////////////////////////////////\n");
                Console.WriteLine(" Получаем Списки объектов после добавления:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name}");
                }
                foreach (Comment u in comments)
                {
                    Console.WriteLine($"{u.User.Name} пишет {u.Text}");
                }

                db.DeleteComment(1);
                db.DeleteUser(1);
     
                Console.WriteLine("\n/////////////////////////////////////////\n");
                users = db.GetUsers();
                comments = db.GetComments();
                Console.WriteLine(" Получаем Списки объектов после удаления:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name}");
                }
                foreach (Comment u in comments)
                {
                    Console.WriteLine($"{u.User.Name} пишет {u.Text}");
                }
            }
        }
        
    }
}