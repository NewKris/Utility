using UnityEngine;

namespace BaraGames.Utility.Attributes {
	public class BoolOptions : PropertyAttribute {
		public readonly string inspectorName;
		public readonly string trueOption;
		public readonly string falseOption;

		public BoolOptions(string inspectorName, string trueOption, string falseOption) {
			this.inspectorName = inspectorName;
			this.trueOption = trueOption;
			this.falseOption = falseOption;
		}
	}
}