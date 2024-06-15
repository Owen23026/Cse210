public class Stretching : Activity
{
    //I took these from wii fit
    private string _warrior =
  @"Warrior Pose:
       (o_o)
    -----|-----
         |
        / \
        \  \   ";
    private string _warriorR =
  @"Warrior Pose:  
       (o_o)
    -----|-----
         |
        / \
       /  /    ";

    private string _halfMoon =
  @"Half Moon Pose:
       X_
       |  \
        \(o_o)
           \ \
            \_\
            |  \
            |  |";

    private string _halfMoonR =
  @"Half Moon Pose: 
             _X
           /  |
        (o_o)/
         //      
        //
       / |
      |  |";

    private string _tree =
  @"Tree Pose: 
        ||    
       /  \  
      (o_o)
        ||      
        ||
       /_|
         |";

    private string _treeR =
  @"Tree Pose: 
        ||    
       /  \  
       (o_o)
        ||      
        ||
        |_\
        |  ";

    public Stretching()
    {
        _title = "Stretching Activity";
        _description = "This activity will help you relax with some stretches.";
    }

    public override void Execute()
    {
        int seconds = Welcome();
       //int i = 0;
        string[] poses = [_warrior, _warriorR, _halfMoon, _halfMoonR, _tree, _treeR];

        Random random = new();

        DateTime fTime = DateTime.Now.AddSeconds(seconds);
        while(fTime > DateTime.Now)
        {
            Console.Clear();
            Console.WriteLine("\n" + poses[random.Next(0, poses.Count() - 1)]);
            Timer.LoadNum(10);
        }
        Done();
    }

}