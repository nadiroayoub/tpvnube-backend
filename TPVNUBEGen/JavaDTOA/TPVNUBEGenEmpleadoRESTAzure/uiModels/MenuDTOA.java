
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
public class MenuDTOA extends DTOA
{
	// region - Members, getters and setters

	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }

	
	private String nombre;
	public String getNombre () { return nombre; }
	public void setNombre (String nombre) { this.nombre = nombre; }
	
	private String foto;
	public String getFoto () { return foto; }
	public void setFoto (String foto) { this.foto = foto; }
	
	private Double precio;
	public Double getPrecio () { return precio; }
	public void setPrecio (Double precio) { this.precio = precio; }
	
	private Double stock;
	public Double getStock () { return stock; }
	public void setStock (Double stock) { this.stock = stock; }
	
	
	/* Rol: Menu o--> Negocio */
	private NegocioDTOA negocioMenu;
	public NegocioDTOA getNegocioMenu () { return negocioMenu; }
	public void setNegocioMenu (NegocioDTOA negocioMenu) { this.negocioMenu = negocioMenu; }

	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public MenuDTOA ()
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

			if (!JSONObject.NULL.equals(json.opt("Foto")))
			{
			 
				this.foto = (String) json.opt("Foto");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Precio")))
			{
			 
			 	String stringDouble = String.valueOf(json.opt("Precio"));
 				this.precio = Double.parseDouble(stringDouble);
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Stock")))
			{
			 
			 	String stringDouble = String.valueOf(json.opt("Stock"));
 				this.stock = Double.parseDouble(stringDouble);
			 
			}
			

			JSONObject jsonNegocioMenu = json.optJSONObject("NegocioMenu");
			if (jsonNegocioMenu != null)
			{
				NegocioDTOA tmp = new NegocioDTOA();
				tmp.setFromJSON(jsonNegocioMenu);
				this.negocioMenu = tmp;
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
		
		
		  if (this.foto != null)
			json.put("Foto", this.foto);
		
		
		  if (this.precio != null)
			json.put("Precio", this.precio);
		
		
		  if (this.stock != null)
			json.put("Stock", this.stock);
		
			

			if (this.negocioMenu != null)
			{
				json.put("NegocioMenu", this.negocioMenu.toJSON());
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
		MenuDTO dto = new MenuDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
	dto.setNombre (this.getNombre());

	dto.setFoto (this.getFoto());

	dto.setPrecio (this.getPrecio());

	dto.setStock (this.getStock());

		
		
		// Roles
					// TODO: from DTOA [ NegocioMenu ] (dataType : NegocioDTOA) to DTO [ Negocio ]
		
		
		return dto;
	}

	// endregion
}

	