namespace VirtualPaws.Application.Exceptions
{
    public class ViolatesForeignKeyException : Exception
    {
        public ViolatesForeignKeyException(string Influences = "|HIDDEN|", 
                                           string Affected = "|HIDDEN|", 
                                           string ForeignKey = "|HIDDEN|") : 
                                           base($"update or delete on table \"{Influences}\" violates foreign key constraint \"{ForeignKey}\" on table \"{Affected}\"")
        { }
    }
}
