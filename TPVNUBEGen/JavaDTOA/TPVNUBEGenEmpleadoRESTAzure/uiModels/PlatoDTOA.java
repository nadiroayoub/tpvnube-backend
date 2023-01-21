
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
public class PlatoDTOA extends DTOA
{
	// region - Members, getters and setters

	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }

	
	private String nombre;
	public String getNombre () { return nombre; }
	public void setNombre (String nombre) { this.nombre = nombre; }
	
	private Double stock;
	public Double getStock () { return stock; }
	public void setStock (Double stock) { this.stock = stock; }
	
	private Double precio;
	public Double getPrecio () { return precio; }
	public void setPrecio (Double precio) { this.precio = precio; }
	
	private String foto;
	public String getFoto () { return foto; }
	public void setFoto (String foto) { this.foto = foto; }
	
	
	/* Rol: Plato o--> Negocio */
	private NegocioDTOA negocioPlato;
	public NegocioDTOA getNegocioPlato () { return negocioPlato; }
	public void setNegocioPlato (NegocioDTOA negocioPlato) { this.negocioPlato = negocioPlato; }

	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public PlatoDTOA ()
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
			

			if (!JSONObject.NULL.equals(json.opt("Nombre")))
			{
			 
				this.nombre = (String) json.opt("Nombre");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Stock")))
			{
			 
			 	String stringDouble = String.valueOf(json.opt("Stock"));
 				this.stock = Double.parseDouble(stringDouble);
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Precio")))
			{
			 
			 	String stringDouble = String.valueOf(json.opt("Precio"));
 				this.precio = Double.parseDouble(stringDouble);
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Foto")))
			{
			 
				this.foto = (String) json.opt("Foto");
			 
			}
			

			JSONObject jsonNegocioPlato = json.optJSONObject("NegocioPlato");
			if (jsonNegocioPlato != null)
			{
				NegocioDTOA tmp = new NegocioDTOA();
				tmp.setFromJSON(jsonNegocioPlato);
				this.negocioPlato = tmp;
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
			
		
		  if (this.nombre != null)
			json.put("Nombre", this.nombre);
		
		
		  if (this.stock != null)
			json.put("Stock", this.stock);
		
		
		  if (this.precio != null)
			json.put("Precio", this.precio);
		
		
		  if (this.foto != null)
			json.put("Foto", this.foto);
		
			

			if (this.negocioPlato != null)
			{
				json.put("NegocioPlato", this.negocioPlato.toJSON());
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
		PlatoDTO dto = new PlatoDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
	dto.setNombre (this.getNombre());

	dto.setStock (this.getStock());

	dto.setPrecio (this.getPrecio());

	dto.setFoto (this.getFoto());

		
		
		// Roles
					// TODO: from DTOA [ NegocioPlato ] (dataType : NegocioDTOA) to DTO [ Negocio ]
		
		
		return dto;
	}

	// endregion
}

	