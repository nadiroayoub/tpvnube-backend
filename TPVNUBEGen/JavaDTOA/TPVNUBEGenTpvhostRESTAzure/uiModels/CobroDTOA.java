
package TPVNUBEGenTpvhostRESTAzure.uiModels.DTOA;

import TPVNUBEGenTpvhostRESTAzure.uiModels.DTO.*;
import TPVNUBEGenTpvhostRESTAzure.uiModels.DTO.utils.*;
import TPVNUBEGenTpvhostRESTAzure.uiModels.DTO.enumerations.*;

import java.util.ArrayList;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

/**
 * Code autogenerated. Do not modify this file.
 */
public class CobroDTOA extends DTOA
{
	// region - Members, getters and setters

	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }

	
	private java.util.Date fecha;
	public java.util.Date getFecha () { return fecha; }
	public void setFecha (java.util.Date fecha) { this.fecha = fecha; }
	
	private float monto;
	public float getMonto () { return monto; }
	public void setMonto (float monto) { this.monto = monto; }
	
	
	/* Rol: Cobro o--> Negocio */
	private NegocioDTOA negocioCobro;
	public NegocioDTOA getNegocioCobro () { return negocioCobro; }
	public void setNegocioCobro (NegocioDTOA negocioCobro) { this.negocioCobro = negocioCobro; }

	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public CobroDTOA ()
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
			

			if (!JSONObject.NULL.equals(json.opt("Fecha")))
			{
			 
			 	String stringDate = (String) json.opt("Fecha");
				this.fecha = DateUtils.stringToDateFormat(stringDate);
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Monto")))
			{
			 
				this.monto = (float) json.opt("Monto");
			 
			}
			

			JSONObject jsonNegocioCobro = json.optJSONObject("NegocioCobro");
			if (jsonNegocioCobro != null)
			{
				NegocioDTOA tmp = new NegocioDTOA();
				tmp.setFromJSON(jsonNegocioCobro);
				this.negocioCobro = tmp;
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
			
		
		  if (this.fecha != null)
			json.put("Fecha", DateUtils.dateToFormatString(this.fecha));
		
		
		  if (this.monto != null)
			json.put("Monto", this.monto);
		
			

			if (this.negocioCobro != null)
			{
				json.put("NegocioCobro", this.negocioCobro.toJSON());
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
		CobroDTO dto = new CobroDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
	dto.setFecha (this.getFecha());

	dto.setMonto (this.getMonto());

		
		
		// Roles
					// TODO: from DTOA [ NegocioCobro ] (dataType : NegocioDTOA) to DTO [ Negocio ]
		
		
		return dto;
	}

	// endregion
}

	