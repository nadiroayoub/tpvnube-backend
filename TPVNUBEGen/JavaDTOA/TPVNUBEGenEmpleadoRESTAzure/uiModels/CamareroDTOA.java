
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
public class CamareroDTOA extends DTOA
{
	// region - Members, getters and setters

	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }

	
	
	/* Rol: Camarero o--> Pedido */
	private ArrayList<PedidoDTOA> pedidos;
	public ArrayList<PedidoDTOA> getPedidos () { return pedidos; }
	public void setPedidos (ArrayList<PedidoDTOA> pedidos) { this.pedidos = pedidos; }

	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public CamareroDTOA ()
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
			
			

			JSONArray arrayPedidos = json.optJSONArray("Pedidos");
			if (arrayPedidos != null)
			{
				this.pedidos = new ArrayList<PedidoDTOA>();
				for (int i = 0; i < arrayPedidos.length(); ++i)
				{
					JSONObject subJson = (JSONObject) arrayPedidos.opt(i);
					PedidoDTOA tmp = new PedidoDTOA();
					tmp.setFromJSON(subJson);
					this.pedidos.add(tmp);
				}
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
			
			

			if (this.pedidos != null)
			{
				JSONArray jsonArray = new JSONArray();
				for (int i = 0; i < this.pedidos.size(); ++i)
				{
					jsonArray.put(this.pedidos.get(i).toJSON());
				}
				json.put("Pedidos", jsonArray);
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
		CamareroDTO dto = new CamareroDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
		
		
		// Roles
					// TODO: from DTOA [ Pedidos ] (dataType : ArrayList<PedidoDTOA>) to DTO [ Pedido ]
		
		
		return dto;
	}

	// endregion
}

	