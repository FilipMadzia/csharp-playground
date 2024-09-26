using PostSharp.Aspects;
using PostSharp.Serialization;

namespace exploring_attributes;

[PSerializable]
class UppercaseAttribute : LocationInterceptionAspect
{
	public override void OnSetValue(LocationInterceptionArgs args)
	{
		if(args.Value is string str)
		{
			args.SetNewValue(str.ToUpper());
		}
		else
		{
			base.OnSetValue(args);
		}
	}
}
