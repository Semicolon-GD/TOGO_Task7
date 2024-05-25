namespace PlayerStateMachine
{
    public interface IState
    {
       
        void EnterState(PlayerManager player);
        void UpdateState(PlayerManager player);
        void ExitState(PlayerManager player );
    }
    
   
}
