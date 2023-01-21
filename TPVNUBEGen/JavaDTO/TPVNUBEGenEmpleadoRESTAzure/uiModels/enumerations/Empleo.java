
package TPVNUBEGenEmpleadoRESTAzure.uiModels.DTO.enumerations;

/**
 * Code autogenerated. Do not modify this file.
 */
public enum Empleo
{
	// region - Literals

	Camarero (1)
	,	Cajero (2)
;

	// endregion


	// region - Members and constructor

	private final int rawValue;

	public int getRawValue ()
	{
		return this.rawValue;
	}

	Empleo (int rawValue)
	{
		this.rawValue = rawValue;
	}

	// endregion


	// region - Public methods

	public static Empleo fromRawValue (int rawValue)
	{
		Empleo[] enumValues = Empleo.values();

		for (int i = 0; i < enumValues.length; i++)
		{
			if (enumValues[i].Compare(rawValue))
			{
				return enumValues[i];
			}
		}

		return null;
	}

	public boolean Compare (int rawValue)
	{
		return this.rawValue == rawValue;
	}

	// endregion
	
}
