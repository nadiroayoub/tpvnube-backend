
package TPVNUBEGenEmpleadoRESTAzure.uiModels.DTOA;

import TPVNUBEGenEmpleadoRESTAzure.uiModels.DTO.*;
import TPVNUBEGenEmpleadoRESTAzure.uiModels.DTO.utils.*;
import TPVNUBEGenEmpleadoRESTAzure.uiModels.DTO.enumerations.*;

import java.util.ArrayList;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

/**
 * Code autogenerated. Do not modify this file.
 */
public class RolCajeroDTOA extends DTOA
{
	// region - Members, getters and setters

	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }

	
	
	/* Rol: RolCajero o--> Cajero */
	private CajeroDTOA cajero;
	public CajeroDTOA getCajero () { return cajero; }
	public void setCajero (CajeroDTOA cajero) { this.cajero = cajero; }

	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public RolCajeroDTOA ()
	{
		// Empty constructor
	}
	
	@Override
	public void setFromJSON (JSONObject json)
	{
		try
		{
			if (!JSONObject.NULL.equals(json.opt("Id")))
			{
				this.id = (Integer) json.opt("Id");
			}
			
			

			JSONObject jsonCajero = json.optJSONObject("Cajero");
			if (jsonCajero != null)
			{
				CajeroDTOA tmp = new CajeroDTOA();
				tmp.setFromJSON(jsonCajero);
				this.cajero = tmp;
			}

			
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
	}
	
	public JSONObject toJSON ()
	{
		JSONObject json = new JSONObject();
		
		try
		{
			if (this.id != null){
				json.put("Id", this.id);
			}
			
			

			if (this.cajero != null)
			{
				json.put("Cajero", this.cajero.toJSON());
			}

			
		}
		catch (JSONException e)
		{
			e.printStackTrace();
		}
		
		return json;
	}
	
	@Override 
	public IDTO toDTO ()
	{
		RolDTO dto = new RolDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
		
		
		// Roles
					// TODO: from DTOA [ Cajero ] (dataType : CajeroDTOA) to DTO [ Cajero ]
		
		
		return dto;
	}

	// endregion
}

	